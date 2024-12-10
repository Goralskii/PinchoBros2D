using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.HID;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Jugador")]
    public MovimientoDelJugador _movimientoDelJugador;
    public ControlJugador _controlJugador;
    public GameObject pinchoObj;
    public CheckPoint _checkPoint;
    [Header("Camaras")]
    public ControlCamara _controlCamara;
    [Header("Canvas")]
    public ControlMenu _controlMenu;
    public HUDManager _hudManager;
    public GameObject botonSiguienteNievel;
    [Header("Estados")]
    public bool enPausa = false;
    public bool inGame = false;
    [Header("Variables GLOBALES")]
    public float tiempo = 90f; // El valor inicial de la cuenta regresiva (300 segundos o cualquier valor deseado)
    public int puntajeGlobal;


    private Vector3 posicionInicial = new Vector3(-11.7299995f, -4.51000023f, 0);

    private void Start()
    {
        CambiarPausa(true);

        if (SceneManager.GetActiveScene().buildIndex > 0)
        {
            _controlMenu.HUD.SetActive(true);
            _movimientoDelJugador.enabled = true;
            inGame = true;
            CambiarPausa(false);
        }
    }

    public void CambiarInGame(bool estado)
    {
        inGame = estado;
    }
    void FixedUpdate()
    {
        //verifica si ya comenzo el juego y empieza a correr el tiempo

        if (inGame)
        {
            if (tiempo <= 0.500f)
            {
                Debug.LogWarning("TIEMPO CERO");
                activarPanelFinJuego();
            }
            else
            {
                tiempo -= Time.deltaTime;

                _hudManager.Tiempo.text = Mathf.FloorToInt(tiempo).ToString();
            }
        }


        // Verifica si el personaje está fuera del mapa
        if (_controlJugador.FueraDeMapa)
        {
            // Reinicia la posición del personaje a la posición inicial
            Respawn();
        }

        //verificar vidas
        controlarVidas();

        if (_checkPoint.nivelCompletado == true)
        {
            tiempo = 0.9f;
            StartCoroutine(DelayAfterLevelCompleted());  
        }
    }

    public void CambiarPausa(bool estado)
    {
        enPausa = estado;
        Time.timeScale = enPausa ? 0f : 1f;
    }

    private void activarPanelFinJuego()
    {
        _controlMenu.FinDelJuego();
        Destroy(pinchoObj, 0.1f);
        StartCoroutine(DelayAntesDeRecargar());
    }

    public void controlarVidas()
    {
        if (_controlJugador.Vidas == 0)
        {
            activarPanelFinJuego();
        }
    }

    public void Respawn()
    {
        pinchoObj.transform.position = posicionInicial;
        _controlJugador.FueraDeMapa = false;
        controlarVidasUI();
    }

    public void controlarVidasUI()
    {
        int indice = _controlJugador.Vidas;
        if (indice >= 0)
        {
            _hudManager.PanelVidas1[indice].GetComponent<Image>().enabled = false;
        }

    }

    public void ReloadScene()
    {
        // Obtener el índice de la escena actual
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Recargar la escena actual
        SceneManager.LoadScene(currentSceneIndex);
    }

    private IEnumerator DelayAntesDeRecargar()
    {
        Debug.Log("Iniciando cuenta regresiva de 5 segundos...");
        yield return new WaitForSeconds(5f);

        SceneManager.LoadScene("level1");
    }

    public void CalcularPuntajeFinal()
    {
        _controlJugador.puntaje += _controlJugador.Gotas * 1000;
    }

    private IEnumerator DelayAfterLevelCompleted()
    {
        Debug.Log("Iniciando cuenta regresiva de 1 segundos...");
        yield return new WaitForSeconds(1f);

        if (_checkPoint.nivelCompletado == true)
        {
            CalcularPuntajeFinal();
            _controlMenu.pasarEstadisticasDeNivel();
            SetearBotonSigNivel();
            _controlMenu.nivelCompletado.SetActive(true);
            _movimientoDelJugador.enabled = false;
        }

        _checkPoint.nivelCompletado = false;
        inGame = false;

    }
    public void siguienteNivel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void SetearBotonSigNivel()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(botonSiguienteNievel);
    }
}
