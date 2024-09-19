using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class GameManager : MonoBehaviour
{
    [Header("Jugador")]
    public MovimientoDelJugador MovimientoDelJugador;
    public ControlJugador controlJugador;
    [Header("Camaras")]
    public ControlCamara controlCamara;
    [Header("Canvas")]
    public ControlMenu controlMenu;
    void Start()
    {
        
    }

    void Update()
    {
        ActivarPanelFinJuego();
    }

    private void ActivarPanelFinJuego()
    {
        if (controlJugador.FueraDeMapa == true)
        {
            controlMenu.FinDelJuego();
            Debug.Log("activar panel game over");
        }
    }
}
