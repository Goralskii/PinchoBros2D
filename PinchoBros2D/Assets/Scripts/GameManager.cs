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

    public int tiempo = 300;

    void Start()
    {

    }

    void Update()
    {
        // Verifica si el personaje está fuera del mapa
        if (_controlJugador.FueraDeMapa)
        {
            //Si se quedo sin vidas
            ActivarPanelFinJuego();
            // Reinicia la posición del personaje a la posición inicial
            Respawn();
            
        }  
    }
    private void ActivarPanelFinJuego()
    {
        // Comprobamos si se cumple la condición de vidas y si el jugador está fuera del mapa
        if (_controlJugador.Vidas < 0)
        {
            Debug.Log("Fin del juego. Vidas agotadas.");
            _controlMenu.FinDelJuego();
            StartCoroutine(DelayAntesDeRecargar());            
        }
        else if (tiempo == 0)
        {
            StartCoroutine(DecrementarTiempo());
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
        Debug.Log("Iniciando cuenta regresiva de 3 segundos...");
        yield return new WaitForSeconds(3f);

        ReloadScene();
    }

    public IEnumerator DecrementarTiempo()
    {
        for (tiempo = 300;  tiempo > 0; tiempo--)
        {
            Debug.Log("decrementando tiempo " + tiempo);
            yield return new WaitForSeconds(1f);
        }

        Debug.Log("¡Tiempo finalizado!");
    }

}
