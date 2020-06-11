using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour

{

    private Animator ar;

    const float MaxHealth = 100f;
    public float health;
    public Slider HealthSlider;

    public AudioSource Dead;
    public AudioSource HealthBonus;

    void Die()
    {

        GetComponent<PlayerMouvement>().enabled = false;
        ar.SetBool("Dead", health <= 0);

    }
     public void TakeDamage(float ammount)
    {
        if (GetComponent<PlayerMouvement>().Invincible == false)
        {
            health -= ammount;
            GetComponent<AudioSource>().Play();

            if (health <= 0)
            {
                health = 0;
                Dead.Play();
                Destroy(Dead);
                Destroy(GetComponent<AudioSource>());
                Die();

            }

        }


    }

    public void HealthRef(float bonus)
    {

        if (health < MaxHealth)
        {

            health += bonus;
            HealthBonus.Play();

            if (health > MaxHealth)
            {

                health = MaxHealth;

            }

        }
    }

    void Start()
    {

        ar = GetComponent<Animator>();

        health = MaxHealth;

    }

   
    void FixedUpdate()
    {
        HealthSlider.value = health;

    }
}
