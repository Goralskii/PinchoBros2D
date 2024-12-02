using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovimientoDelJugador : MonoBehaviour
{
    public float runSpeed = 2;

    public float JumpSpeed = 3;

    //public float velocidad = 5f;

    public Rigidbody2D rb2D;

    [Header("Referencias")]
    public ControlJugador _controlJugador;
    [Header("Animaciones")]
    public Animator animator;
    public SpriteRenderer pinchoSprite;
    [Header("Variables")]
    public float maxJumpTime = 0.35f;  // El tiempo máximo que puede durar el salto
    private float jumpTimeCounter;
    public float acceleration = 0.1f;
    public float deceleration = 0.1f;
    private float currentSpeed = 0f;
    private float gamePadAxis;

    Gamepad gp = null;





    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        gp = InputSystem.GetDevice<Gamepad>();

    }

    private void movALaDerecha()
    {
        currentSpeed = Mathf.Min(currentSpeed + acceleration, runSpeed);
        rb2D.velocity = new Vector2(runSpeed, rb2D.velocity.y);
        animator.SetFloat("movimiento", rb2D.velocity.x);
        animator.SetBool("reposo", false);
        pinchoSprite.flipX = true;
    }

    private void movALaIzquierda()
    {
        currentSpeed = Mathf.Max(currentSpeed - acceleration, -runSpeed);
        rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);
        animator.SetFloat("movimiento", -rb2D.velocity.x);
        animator.SetBool("reposo", false);
        pinchoSprite.flipX = false;
    }

    private void quedarseQuieto()
    {
        currentSpeed = Mathf.MoveTowards(currentSpeed, 0, deceleration);
        rb2D.velocity = new Vector2(0, rb2D.velocity.y);

        if (rb2D.velocity.x == 0)
        {
            jumpTimeCounter = 0;
            animator.SetFloat("movimiento", 0);
            animator.SetBool("reposo", true);
        }
    }

    private void saltar()
    {
        rb2D.velocity = new Vector2(rb2D.velocity.x, JumpSpeed);
        jumpTimeCounter = maxJumpTime;
        animator.SetBool("enSuelo", false);

        if (jumpTimeCounter > 0)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, JumpSpeed);
            jumpTimeCounter -= Time.deltaTime;
        }
    }
    //private void movGamepad()
    //{
    //    if (gp.leftStick.ReadValue().x > 0)
    //    {
    //        movALaDerecha();
    //    }
    //    else if (gp.leftStick.ReadValue().x < 0)
    //    {
    //        movALaIzquierda();
    //    }
    //    else
    //    {
    //        quedarseQuieto();
    //    }
    //}

    private void saltoGP()
    {
        if (gp.buttonSouth.ReadValue() > 0)
        {
            saltar();
        }
    }

    private void movTeclado()
    {
        if (gamePadAxis > 0 || Input.GetKey("d") || Input.GetKey("right"))
        {
            movALaDerecha();
        }
        else if (gamePadAxis < 0 || Input.GetKey("a") || Input.GetKey("left"))
        {
            movALaIzquierda();
        }
        else
        {
            quedarseQuieto();
        }
    }

    private void SaltoTeclado()
    {
        if (Input.GetKey("w") || Input.GetKey("up"))
        {
            saltar();
        }
    }
    void Update()
    {
        gamePadAxis = Input.GetAxis("Horizontal");
        //movGamepad();
        movTeclado();

        if (_controlJugador.enSuelo)
        {
            animator.SetBool("enSuelo", true);
            // Movimiento cuando está en el suelo
            rb2D.velocity = new Vector2(Input.GetAxis("Horizontal") * runSpeed, rb2D.velocity.y);
            saltoGP();
            SaltoTeclado();
        }
        else
        {
            //Movimiento limitado en el aire
            rb2D.velocity = new Vector2(Input.GetAxis("Horizontal") * runSpeed * 0.8f, rb2D.velocity.y);
        }    
    }
}
