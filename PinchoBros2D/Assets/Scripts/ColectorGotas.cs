using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColectorGotas : MonoBehaviour
{

    public HUDManager _hudManager;
    public ControlJugador _jugador;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().enabled = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            _jugador.Gotas += 1;//esto no va aca
            Destroy(gameObject,0.5f);
        }
    }
}
