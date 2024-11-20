using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    [Header("Variables Publicas")]
    public bool inGame = false;
    public float tiempo = 100f; // El valor inicial de la cuenta regresiva (300 segundos o cualquier valor deseado)

    private Vector3 posicionInicial = new Vector3(-11.7299995f, -4.51000023f, 0);



    void Start()
    {

    }

    void Update()
    {
        //verifica si ya comenzo el juego y empieza a correr el tiempo
        if (inGame)
        {
            tiempo -= Time.deltaTime;
            if (tiempo <= 0)
            {
                ActivarPanelFinJuego();
            }
            _hudManager.Tiempo.text = Mathf.FloorToInt(tiempo).ToString();
        }

        // Verifica si el personaje est� fuera del mapa
        if (_controlJugador.FueraDeMapa)
        {
            //Si se quedo sin vidas
            ActivarPanelFinJuego();
            // Reinicia la posici�n del personaje a la posici�n inicial
            Respawn();

        }

        if (_checkPoint.nivelCompletado == true)
        {
            CalcularPuntajeFinal();
            StartCoroutine(DelayAfterLevelCompleted());
        }

    }


    private void ActivarPanelFinJuego()
    {
        // Comprobamos si se cumple la condici�n de vidas y si el jugador est� fuera del mapa
        if (_controlJugador.Vidas == 0)
        {
            Debug.Log("Fin del juego. Vidas agotadas.");
            _controlMenu.FinDelJuego();
            Destroy(pinchoObj, 0.1f);
            StartCoroutine(DelayAntesDeRecargar());

        }
    }



    public void Respawn()
    {
        pinchoObj.transform.position = posicionInicial;
        _controlJugador.FueraDeMapa = false;
        ControlarVidas();
    }

    private void ControlarVidas()
    {
        int indice = _controlJugador.Vidas;
        if (indice >= 0)
        {
            _hudManager.PanelVidas1[indice].GetComponent<Image>().enabled = false;
        }

    }

    public void ReloadScene()
    {
        // Obtener el �ndice de la escena actual
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Recargar la escena actual
        SceneManager.LoadScene(currentSceneIndex);
    }

    private IEnumerator DelayAntesDeRecargar()
    {
        Debug.Log("Iniciando cuenta regresiva de 5 segundos...");
        yield return new WaitForSeconds(5f);

        ReloadScene();
    }

    public void CalcularPuntajeFinal()
    {
        int i;

        for (i = 0; i < _controlJugador.Gotas; i++)
        {
            _controlJugador.puntaje += 1000;
            _controlJugador.Gotas -= 1;
        }

        for( i = 0; i< tiempo; i++)
        {
            _controlJugador.puntaje += 10;
            tiempo -= 1;
        }

    }

    private IEnumerator DelayAfterLevelCompleted()
    {
        Debug.Log("Iniciando cuenta regresiva de 3 segundos...");
        yield return new WaitForSeconds(3f);

        _controlMenu.nivelCompletado.SetActive(true);
        inGame = false;

    }
}
