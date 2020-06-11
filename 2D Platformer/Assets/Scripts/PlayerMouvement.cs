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
    public float CheckRadius;

    public bool FacingRight = true;

    public Transform Ground;
    public LayerMask GroundLayer;

    private Rigidbody2D rb;
    private Animator ar;

    public AudioSource Jump;

    public bool Invincible = false;
    public int TimeOfExecution = 0;

    int ExtraJumps;
    public int ExtraJumpsMax;

    

    IEnumerator DoubleJump()
    {
        JumpForce *= 2;
        yield return new WaitForSeconds(5f);
        JumpForce /= 2;

    }

    IEnumerator PowerUp()
    {
        Invincible = true;
        gameObject.GetComponent<Renderer>().material.color = Color.green;

        yield return new WaitForSeconds(5f);

        Invincible = false ;
        gameObject.GetComponent<Renderer>().material.color = Color.white;   
    }



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

        Vector2 targetvelocity;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            targetvelocity = new Vector2(x * Speed * 1.5f, rb.velocity.y);

        }
        else
        {
            targetvelocity = new Vector2(x * Speed, rb.velocity.y);

        }

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

        GroundCheck = Physics2D.OverlapCircle(Ground.position, CheckRadius, GroundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && GroundCheck == true  )
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
            Jump.Play();
            ExtraJumps = ExtraJumpsMax;
            
            
        }

        if (Input.GetKeyDown("e"))
        {

            StartCoroutine("DoubleJump");

        }
        if (GetComponent<ScoreManager>().score >= 4 && TimeOfExecution == 0) 
        {

            TimeOfExecution++;
            StartCoroutine("PowerUp");

        }

        if(Input.GetKeyDown(KeyCode.Space) && ExtraJumps > 0 && GroundCheck == false)
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
            Jump.Play();
            ExtraJumps--;

        }
    }
}
