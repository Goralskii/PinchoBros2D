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

        if (Input.GetKey("w") && _comprobarSuelo.enSuelo)
        {
            rb2D.velocity= new Vector2(rb2D.velocity.x,JumpSpeed);
        }

        if(rb2D.velocity.x == 0)
        {
            animator.SetBool("reposo", true);
        }
        /*float velocidadX = Input.GetAxis("Horizontal")*Time.deltaTime*velocidad;

        Vector3 posicion = transform.position;

        transform.position = new Vector3(velocidadX + posicion.x, posicion.y, posicion.z);*/

    }
}
