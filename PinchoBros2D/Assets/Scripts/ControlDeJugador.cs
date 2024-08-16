using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDeJugador : MonoBehaviour
{
    public float runSpeed = 2;

    public float JumpSpeed = 3;

    //public float velocidad = 5f;

    Rigidbody2D rb2D;


    public Animator animator;
    
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

  
    void FixedUpdate()
    {

        if (Input.GetKey("d") || Input.GetKey("Right"))
        {
            rb2D.velocity = new Vector2 (runSpeed, rb2D.velocity.y);
        }
        else if (Input.GetKey("a") || Input.GetKey("Left"))
        {
            rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);
        }
        else
        {
            rb2D.velocity = new Vector2(0,rb2D.velocity.y);
        }


        /*float velocidadX = Input.GetAxis("Horizontal")*Time.deltaTime*velocidad;

        Vector3 posicion = transform.position;

        transform.position = new Vector3(velocidadX + posicion.x, posicion.y, posicion.z);*/

    }
}
