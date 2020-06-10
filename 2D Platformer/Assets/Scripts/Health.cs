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

    void Die()
    {

        GetComponent<PlayerMouvement>().enabled = false;
        ar.SetBool("Dead", health <= 0);

    }
     public void TakeDamage(float ammount)
    {

        health -= ammount;

        if (health <= 0)
        {

            health = 0;
            Die();

        }


    }

    public void HealthRef(float bonus)
    {

        if (health < MaxHealth)
        {

            health += bonus;

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
