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
        // Verifica si el personaje est� fuera del mapa
        if (_controlJugador.FueraDeMapa)
        {
            // Reinicia la posici�n del personaje a la posici�n inicial
            Respawn();
        }
    }

    private void ActivarPanelFinJuego()
    {
        if (_controlJugador.FueraDeMapa == true && _controlJugador.Vidas < 0)
        {
            _controlMenu.FinDelJuego();
            Debug.Log("activar panel game over");
            _controlMenu.enPausa = true;

            // Iniciar la corrutina para agregar el delay
            StartCoroutine(DelayAntesDeRecargar());
        }
    }

    private IEnumerator DelayAntesDeRecargar()
    {
        // Espera de 5 segundos
        yield return new WaitForSeconds(5f);

        // Llamar a la funci�n ReloadScene
        ReloadScene();
    }


    public void Respawn()
    {
        pinchoObj.transform.position = posicionInicial;
        _controlJugador.FueraDeMapa = false;
        ControlarVidas();
    }

    private void ControlarVidas()
    {
        int indice = _controlJugador.Vidas + 1;

        // Verificar que el �ndice est� dentro de los l�mites del array
        if (indice >= 0 && indice < _hudManager.PanelVidas1.Length)
        {
            _hudManager.PanelVidas1[indice].GetComponent<Image>().enabled = false;
        }
        else
        {
            Debug.LogWarning("El �ndice est� fuera de rango: " + indice);
        }
    }


    //private void ControlarVidas()
    //{
    //   _hudManager.PanelVidas1[_controlJugador.Vidas + 1].GetComponent<Image>().enabled = false;
    //}

    public void ReloadScene()
    {
        // Obtener el �ndice de la escena actual
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Recargar la escena actual
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void Pausa()
    {
        if (_controlMenu.enPausa == true)
        {
            _controlMenu.enPausa = false;
        }else if (_controlMenu.enPausa == false)
        {
            _controlMenu.enPausa = true;
        }
    }
}
