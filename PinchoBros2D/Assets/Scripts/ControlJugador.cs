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
        enSuelo = true;
        if (collision.CompareTag("Limite"))
        {
            Debug.Log("Derrota");
            FueraDeMapa = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        enSuelo = false;
    }

}
