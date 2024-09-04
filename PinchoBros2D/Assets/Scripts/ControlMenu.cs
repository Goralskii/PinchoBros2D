using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMenu : MonoBehaviour
{
    public static ControlMenu instance;
    public GameObject MenuPrincipal;
    public bool enPausa = true;
    public MovimientoDelJugador MovimientoDelJugador;
    public GameObject juegoTerminado;
    void Start()
    {
        
    }

    void Update()
    {
        if (enPausa == true)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void BotonJugar()
    {
        MenuPrincipal.SetActive(false);
        enPausa = false;
        MovimientoDelJugador.enabled = true;
    }

    public void FinDelJuego()
    {
        juegoTerminado.SetActive(true);
    }
}
