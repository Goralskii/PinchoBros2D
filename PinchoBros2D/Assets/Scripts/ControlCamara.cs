using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamara : MonoBehaviour
{
    public Transform Personaje;

    public float tamaņoCamara;
    public float ubicacionPantalla;

    void Start()
    {
        tamaņoCamara = Camera.main.orthographicSize;
        ubicacionPantalla = tamaņoCamara * 2;
    }

    void Update()
    {
        
    }
}
