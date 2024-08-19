using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComprobarSuelo : MonoBehaviour
{
    public bool enSuelo;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        enSuelo = true;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        enSuelo = false;
    }
}
