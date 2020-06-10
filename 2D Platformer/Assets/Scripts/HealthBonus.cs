using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBonus : MonoBehaviour
{

    public float Bonus;


     void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent<Health>().health < 100f && collision.gameObject.GetComponent<Health>().health > 0)
            {
                collision.gameObject.GetComponent<Health>().HealthRef(Bonus);

                Destroy(gameObject);

            }

        }
    }


    void Start()
    {
     
        

    }
    void FixedUpdate()
    {
        
    }
}
