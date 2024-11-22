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
    [Header("Paneles")]
    public GameObject juegoTerminado;
    public GameObject HUD;
    public GameObject MenuPrincipal;
    public GameObject PanelPausa;
    public GameObject nivelCompletado;
    public GameObject ayuda;

    void Update()
    {

    }

    public void BotonAlMenu()
    {
        _gameManager.ReloadScene();
    }

    public void volerAlMenu()
    {
        ayuda.SetActive(false);
        MenuPrincipal.SetActive(true);
    }

    public void BotonJugar()
    {
        MenuPrincipal.SetActive(false);
        HUD.SetActive(true);
        _gameManager.enPausa = false;
        _movimientoDelJugador.enabled = true;
        _gameManager.inGame = true;
        
    }

    public void FinDelJuego()
    {
        juegoTerminado.SetActive(true);
    }

    public void Pausa()
    {
        if (_gameManager.enPausa == true)
        {
            _gameManager.enPausa = false;
            PanelPausa.SetActive(false);
        }
        else if (_gameManager.enPausa == false)
        {
            _gameManager.enPausa = true;
            PanelPausa.SetActive(true);
        }
    }

    public void botonAyudas()
    {
        MenuPrincipal.SetActive(false);
        ayuda.SetActive(true);
    }

    public void Salir()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
