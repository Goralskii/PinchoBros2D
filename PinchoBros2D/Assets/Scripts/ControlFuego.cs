using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlFuego : MonoBehaviour
{
    public ControlJugador _controlJugador;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _controlJugador.Gotas -= 3;
            GetComponent<SpriteRenderer>().enabled = false;
            Destroy(gameObject, 0.5f);
        }
    }


    
}
