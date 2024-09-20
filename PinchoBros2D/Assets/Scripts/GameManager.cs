using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        if (_controlJugador.FueraDeMapa == true)
        {
            _controlMenu.FinDelJuego();
            Debug.Log("activar panel game over");
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
       _hudManager.PanelVidas1[_controlJugador.Vidas + 1].GetComponent<Image>().enabled = false;
    }
}
