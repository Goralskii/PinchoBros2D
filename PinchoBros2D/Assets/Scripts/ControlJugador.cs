using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ControlJugador : MonoBehaviour
{
    public bool enSuelo;
    public bool FueraDeMapa;
    [Header("Stats")]
    public int puntaje;
    public int Vidas;
    public int Gotas;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Suelo"))
        {
            enSuelo = true;
        }

        if (collision.CompareTag("Limite") && !FueraDeMapa) // Solo se ejecuta si aún no está fuera del mapa
        {
            Debug.Log("Derrota");
            FueraDeMapa = true;
            RestarVida();
            enSuelo = false;
            Debug.Log("vidas restantes: " + Vidas);
        }

        if (collision.CompareTag("Gota"))
        {
            Gotas += 1;
            SumarPuntaje();
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        enSuelo = false;
    }


    public void RestarVida()
    {
       if (FueraDeMapa)
        {
            Vidas -= 1;
        } 
    }

    public void SumarPuntaje()
    {
        puntaje = Gotas * 100;
    }
}
