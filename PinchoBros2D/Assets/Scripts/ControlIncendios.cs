using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlIncendios : MonoBehaviour
{
    public GameObject Fuego;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.gameObject == Fuego)
        {
            Debug.Log("Contacto con Fuego");
            GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
