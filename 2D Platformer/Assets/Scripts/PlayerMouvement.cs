using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{

    public float Speed;
    public float Smooth;

    public float JumpForce;
    public bool GroundCheck;

    public bool FacingRight = true;

    public Collider2D Ground;
    public LayerMask GroundLayer;

    private Rigidbody2D rb;
    private Animator ar;

    void Flip()
    {
        FacingRight = !FacingRight;

        Vector2 Scale = transform.localScale;

        Scale.x = Scale.x * -1;

        transform.localScale = Scale;


    }
    
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        ar = GetComponent<Animator>();
    }


    void FixedUpdate()
    {

        float x = Input.GetAxisRaw("Horizontal");

        ar.SetBool("Running", x != 0 && GroundCheck == true);

        Vector2 targetvelocity = new Vector2(x * Speed, rb.velocity.y);

        rb.velocity = Vector2.SmoothDamp(rb.velocity, targetvelocity, ref targetvelocity, Time.deltaTime * Smooth);


        if (x < 0 && FacingRight == true)
        {

            Flip();


        }

        if (x > 0 && FacingRight == false)
        {

            Flip();


        }

       

    }

    private void Update()
    {

        ar.SetBool("Jumping", !GroundCheck && rb.velocity.y > 0);


        ar.SetBool("Falling",  rb.velocity.y < 0);

        GroundCheck = Ground.IsTouchingLayers(GroundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && GroundCheck == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
        }
    }
}
