using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlFuego : MonoBehaviour
{
    public ControlJugador _controlJugador;
    public GameManager _gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (_controlJugador.Gotas < 3)
            {
                _controlJugador.Gotas = 0;
                Debug.Log("-1 Vida");
                _controlJugador.Vidas -=1;
                _gameManager.controlarVidasUI();
            }
            else
            {
                _controlJugador.Gotas -= 3;
            }
            GetComponent<SpriteRenderer>().enabled = false;
            Destroy(gameObject, 0.5f);
        }
    }
}
