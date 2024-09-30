 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoDelJugador : MonoBehaviour
{
    public float runSpeed = 2;

    public float JumpSpeed = 3;

    //public float velocidad = 5f;

    public Rigidbody2D rb2D;

    public ControlJugador _controlJugador;


    public Animator animator;
    public SpriteRenderer pinchoSprite;

    public float maxJumpTime = 0.35f;  // El tiempo máximo que puede durar el salto
    private float jumpTimeCounter;

    public float acceleration = 0.1f;
    public float deceleration = 0.1f;
    private float currentSpeed = 0f;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

  
    void Update()
    {
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            currentSpeed = Mathf.Min(currentSpeed + acceleration, runSpeed);
            rb2D.velocity = new Vector2(runSpeed, rb2D.velocity.y);
            animator.SetFloat("movimiento", rb2D.velocity.x);
            animator.SetBool("reposo", false);
            pinchoSprite.flipX = true;
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            currentSpeed = Mathf.Max(currentSpeed - acceleration, -runSpeed);
            rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);
            animator.SetFloat("movimiento", -rb2D.velocity.x);
            animator.SetBool("reposo", false);
            pinchoSprite.flipX = false;
        }
        else
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0, deceleration);
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
        }

        if (_controlJugador.enSuelo)
        {
            animator.SetBool("enSuelo", true);
            // Movimiento cuando está en el suelo
            rb2D.velocity = new Vector2(Input.GetAxis("Horizontal") * runSpeed, rb2D.velocity.y);

            if (Input.GetKey("w") || Input.GetKey("up"))
            {
                rb2D.velocity = new Vector2(rb2D.velocity.x, JumpSpeed);
                jumpTimeCounter = maxJumpTime;
                animator.SetBool("enSuelo", false) ;
            }

            if ((Input.GetKey("w") || Input.GetKey("up")) && jumpTimeCounter > 0)
            {
                rb2D.velocity = new Vector2(rb2D.velocity.x, JumpSpeed);
                jumpTimeCounter -= Time.deltaTime;
            }

            if (rb2D.velocity.x == 0)
            {
                jumpTimeCounter = 0;
                animator.SetBool("reposo", true);
            }
        }
        else
        {
            // Movimiento limitado en el aire
            rb2D.velocity = new Vector2(Input.GetAxis("Horizontal") * runSpeed * 0.8f, rb2D.velocity.y);
        }


    }
}
