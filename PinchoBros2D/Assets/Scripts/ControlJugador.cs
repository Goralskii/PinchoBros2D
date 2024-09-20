using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlJugador : MonoBehaviour
{
    public bool enSuelo;
    public bool FueraDeMapa;
    [Header("Stats")]
    public int puntaje;
    public int Vidas;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Suelo"))
        {
            enSuelo = true;
        }

        if (collision.CompareTag("Limite"))
        {
            Debug.Log("Derrota");
            FueraDeMapa = true;
            enSuelo = false;
            Vidas -= 1;
            Debug.Log("vidas restantes: "+ Vidas);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        enSuelo = false;
    }

}
