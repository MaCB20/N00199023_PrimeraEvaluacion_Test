using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorController : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator an;
    public float Horizontal;
    public float velocity;
    public float jumpForce;
    //public float velocityForce;
    bool jump = true;
    const int A_Quieto = 0;
    const int A_Correr = 1;
    const int A_Saltar = 2;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        sr = GetComponent<SpriteRenderer>();

        an = GetComponent<Animator>();

    }
    void Update()
    {
        
        Horizontal = Input.GetAxisRaw("Horizontal") * velocity;
        ChangeAnimation(A_Quieto);

        if(Horizontal > 0.0f)
        {
            sr.flipX = false;
            ChangeAnimation(A_Correr);
        } 
        else if(Horizontal < 0.0f)
        {
            sr.flipX = true;
            ChangeAnimation(A_Correr);
        }

        if(Input.GetKeyDown(KeyCode.Space) && jump)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            jump = false;
            ChangeAnimation(A_Saltar);
        }

        // if(Input.GetKeyDown(KeyCode.LeftShift))
        // {
        //     rb.AddForce(new Vector2(velocityForce, 0), ForceMode2D.Impulse);

        // }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        jump = true;
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(Horizontal, rb.velocity.y);
    }
    void ChangeAnimation(int animation)
    {
        an.SetInteger("Estado", animation);
    }
}
