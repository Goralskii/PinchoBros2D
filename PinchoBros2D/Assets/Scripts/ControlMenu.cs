using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMenu : MonoBehaviour
{
    public static ControlMenu instance;
    public GameObject MenuPrincipal;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void BotonJugar()
    {
        MenuPrincipal.SetActive(false);
    }
}
