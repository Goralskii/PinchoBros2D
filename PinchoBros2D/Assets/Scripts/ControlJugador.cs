using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ControlJugador : MonoBehaviour
{
    [Header("Estados")]
    public bool FueraDeMapa;
    public bool enSuelo;
    [Header("Stats")]
    public int puntaje;
    public int Vidas;
    public int Gotas;
    public int incendiosApagados;

    private void Start()
    {
       
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Limite") && !FueraDeMapa) // Solo se ejecuta si a�n no est� fuera del mapa
        {
            Debug.Log("Derrota");
            FueraDeMapa = true;
            RestarVida();
            Debug.Log("vidas restantes: " + Vidas);
        }

        if (collision.CompareTag("Gota"))
        {
            Gotas += 1;
            puntaje += 100;
        }

        if (collision.CompareTag("Fuego"))
        {
            incendiosApagados += 1;
            puntaje += 500;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Suelo")
        {
            enSuelo = true;
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
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

}
