using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamara : MonoBehaviour
{
    public Transform Personaje;

    public float tamañoCamara;
    public float ubicacionPantalla;

    void Start()
    {
        tamañoCamara = Camera.main.orthographicSize;
        ubicacionPantalla = tamañoCamara * 2;
    }

    void Update()
    {
        
    }
}
