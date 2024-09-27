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
    [Header("Camaras")]
    public ControlCamara _controlCamara;
    [Header("Canvas")]
    public ControlMenu _controlMenu;
    public HUDManager _hudManager;

    private Vector3 posicionInicial = new Vector3(-11.7299995f, -4.51000023f, 0);

    void Start()
    {

    }

    void Update()
    {
        ActivarPanelFinJuego();
        // Verifica si el personaje está fuera del mapa
        if (_controlJugador.FueraDeMapa)
        {
            // Reinicia la posición del personaje a la posición inicial
            Respawn();
        }  
    }
    private void ActivarPanelFinJuego()
    {
        // Comprobamos si se cumple la condición de vidas y si el jugador está fuera del mapa
        if (_controlJugador.FueraDeMapa == true  && _controlJugador.Vidas < 0)
        {
            Debug.Log("Fin del juego. Vidas agotadas.");
            _controlMenu.FinDelJuego();
            StartCoroutine(DelayAntesDeRecargar()); // Inicia el retraso antes de recargar
        }
        else
        {
            Debug.Log("El juego aún continúa.");
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
        // Obtener el índice de la escena actual
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Recargar la escena actual
        SceneManager.LoadScene(currentSceneIndex);
    }

    private IEnumerator DelayAntesDeRecargar()
    {
        Debug.Log("Iniciando cuenta regresiva de 5 segundos...");
        yield return new WaitForSeconds(5f);

        Debug.Log("Recargando escena...");
        ReloadScene();
    }
}
