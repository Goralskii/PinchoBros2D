using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDeJugador : MonoBehaviour
{
    public float runSpeed = 2;

    public float JumpSpeed = 3;

    //public float velocidad = 5f;

    public Rigidbody2D rb2D;

    public ComprobarSuelo _comprobarSuelo;


    public Animator animator;
    public SpriteRenderer pinchoSprite;
    
    void Start()
    {

        rb2D = GetComponent<Rigidbody2D>();
    }

  
    void Update()
    {

        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb2D.velocity = new Vector2 (runSpeed, rb2D.velocity.y);
            animator.SetFloat("movimiento", rb2D.velocity.x);
            animator.SetBool("reposo", false);
            pinchoSprite.flipX = true;
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);
            animator.SetFloat("movimiento", -rb2D.velocity.x);
            animator.SetBool("reposo", false);
            pinchoSprite.flipX = false;
        }
        else
        {
            rb2D.velocity = new Vector2(0,rb2D.velocity.y);
        }

        if (_comprobarSuelo.enSuelo)
        {
            animator.SetBool("enSuelo", true);
            if (Input.GetKey("w") || Input.GetKey("up"))
            {
                rb2D.velocity = new Vector2(rb2D.velocity.x, JumpSpeed);
                animator.SetBool("saltando", true);
                animator.SetBool("levantarse", true) ;
            }
        }

        if (rb2D.velocity.x == 0)
        {
            animator.SetBool("reposo", true);

            if (Input.GetKey("s") || Input.GetKey("down"))
            {
                animator.SetBool("sentarse", true);
            }
        }
        //if(rb2D.velocity.x == 0)
        //{
        //    animator.SetBool("reposo", true);
        //    if (Input.GetKey("s") || Input.GetKey("down"))
        //    {
        //        animator.SetBool("sentarse", true) ;
        //    }
        //    else if (Input.GetKey("space"))
        //    {
        //        animator.SetBool("levantarse", true);
        //    }
        //}
    }
}
