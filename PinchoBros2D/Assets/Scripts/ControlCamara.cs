using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamara : MonoBehaviour
{
    public Transform Personaje;

    public float tama�oCamara;
    public float ubicacionPantalla;

    void Start()
    {
        tama�oCamara = Camera.main.orthographicSize;
        ubicacionPantalla = tama�oCamara * 2;
    }

    void Update()
    {
        
    }
}
