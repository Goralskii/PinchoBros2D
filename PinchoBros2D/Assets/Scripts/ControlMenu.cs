using System.Collections;
using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ControlMenu : MonoBehaviour
{
    public static ControlMenu instance;
    [Header("Referencias")]
    public MovimientoDelJugador _movimientoDelJugador;
    public GameManager _gameManager;
    public CheckPoint _checkponit;
    [Header("Booleanos")]
    public bool enPausa = true;
    [Header("Paneles")]
    public GameObject juegoTerminado;
    public GameObject HUD;
    public GameObject MenuPrincipal;
    public GameObject PanelPausa;
    public GameObject nivelCompletado;
    public GameObject ayuda;

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
        _movimientoDelJugador.enabled = true;
        _gameManager.inGame = true;
        
    }

    public void FinDelJuego()
    {
        juegoTerminado.SetActive(true);
    }

    public void Pausa()
    {
        if (enPausa == true)
        {
            enPausa = false;
            PanelPausa.SetActive(false);
        }
        else if (enPausa == false)
        {
            enPausa = true;
            PanelPausa.SetActive(true);
        }
    }

    public void botonAyudas()
    {
        MenuPrincipal.SetActive(false);
        ayuda.SetActive(true);
    }
}
