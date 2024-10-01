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

    [Header("Variables Publicas")]
    public bool inGame = false;
    public float tiempo = 300f; // El valor inicial de la cuenta regresiva (300 segundos o cualquier valor deseado)

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
            Destroy(pinchoObj,0.5f);
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
        // Obtener el índice de la escena actual
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


}
