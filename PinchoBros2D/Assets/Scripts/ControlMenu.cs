
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;



public class ControlMenu : MonoBehaviour
{
    public static ControlMenu instance;
    [Header("Referencias")]
    public ControlJugador _controlJugador;
    public MovimientoDelJugador _movimientoDelJugador;
    public GameManager _gameManager;
    public CheckPoint _checkpoint;
    [Header("Paneles")]
    public GameObject juegoTerminado;
    public GameObject HUD;
    public GameObject MenuPrincipal;
    public GameObject PanelPausa;
    public GameObject nivelCompletado;
    public GameObject ayuda;
    [Header("BOTONES")]
    public GameObject botonIniciarNivel;
   
    [Header("Variables Texto Score")]
    public Text puntajeDeNivel;
    public Text gotasExtras;
    public Text focosIncendiosApagados;


    public void BotonAlMenu()
    {
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            _gameManager.ReloadScene();
        }
        
    }

    public void volerAlMenu()
    {
        ayuda.SetActive(false);
        MenuPrincipal.SetActive(true);
    }

    public void BotonJugar()
    {
        MenuPrincipal.SetActive(false);
        ayuda.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(botonIniciarNivel);
    }

    public void EmpezarNivel()
    {
        ayuda.SetActive(false);
        HUD.SetActive(true);
        _gameManager.CambiarPausa(false);
        _gameManager.inGame = true;
        _movimientoDelJugador.enabled = true;
    }

    public void FinDelJuego()
    {
        juegoTerminado.SetActive(true);
    }

    public void Pausa()
    {
        if (_gameManager.enPausa == true)
        {
            _gameManager.CambiarPausa(false);
            PanelPausa.SetActive(false);
        }
        else if (_gameManager.enPausa == false)
        {
            _gameManager.CambiarPausa(true);
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

    public void pasarEstadisticasDeNivel()
    {
        puntajeDeNivel.text = _controlJugador.puntaje.ToString();
        gotasExtras.text = _controlJugador.Gotas.ToString();
        focosIncendiosApagados.text = _controlJugador.incendiosApagados.ToString();
    }
}
