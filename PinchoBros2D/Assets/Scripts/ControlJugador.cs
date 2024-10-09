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

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Limite") && !FueraDeMapa) // Solo se ejecuta si aún no está fuera del mapa
        {
            Debug.Log("Derrota");
            FueraDeMapa = true;
            RestarVida();
            Debug.Log("vidas restantes: " + Vidas);
        }

        if (collision.CompareTag("Gota"))
        {
            Gotas += 1;
            puntaje += Gotas * 100;
        }

        //if (collision.CompareTag("Suelo"))
        //{
        //    enSuelo = true;
        //}
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

    void Update()
    {
        
    }

    public void RestarVida()
    {
       if (FueraDeMapa)
        {
            Vidas -= 1;
        } 
    }
}
