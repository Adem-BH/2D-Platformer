using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LethalScript : MonoBehaviour
{

    public float Damage = 5f;
    public bool Push;
    public float Force;

    private Rigidbody2D rb;


    private void OnCollisionEnter2D(Collision2D col) { 
    

   
        if(col.gameObject.tag == "Player"){

            col.gameObject.GetComponent<Health>().TakeDamage(Damage);


            if (Push == true)
            {

                Vector2 PushDirection = col.transform.position - transform.position;
                rb = col.gameObject.GetComponent<Rigidbody2D>();
                rb.velocity = PushDirection * Force;
                

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
