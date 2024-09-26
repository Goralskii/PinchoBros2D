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
        if (_controlJugador.FueraDeMapa == true && _controlJugador.Vidas < 0)
        {
            _controlMenu.FinDelJuego();
            ReloadScene();  
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

    //public void Pausa()
    //{
    //    if (_controlMenu.enPausa == true)
    //    {
    //        _controlMenu.enPausa = false;
    //    }else if (_controlMenu.enPausa == false)
    //    {
    //        _controlMenu.enPausa = true;
    //    }
    //}
}
