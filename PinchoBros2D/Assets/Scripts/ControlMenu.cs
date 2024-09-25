using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ControlMenu : MonoBehaviour
{
    public static ControlMenu instance;
    public GameObject MenuPrincipal;
    public bool enPausa = true;
    public MovimientoDelJugador MovimientoDelJugador;
    public GameObject juegoTerminado;
    public GameObject HUD;

    public bool inGame = false;
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
        HUD.SetActive(true);
        enPausa = false;
        MovimientoDelJugador.enabled = true;
        inGame = true;
    }

    public void FinDelJuego()
    {
        juegoTerminado.SetActive(true);
    }

}
