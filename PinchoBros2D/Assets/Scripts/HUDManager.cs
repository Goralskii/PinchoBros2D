using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    [Header("Referencias")]
    public ControlJugador _controlJugador;
    public GameManager gameManager;
    [Header("Arreglos")]
    public GameObject[] PanelVidas0;
    public GameObject[] PanelVidas1;
    [Header("Variables Texto HUD")]
    public Text gotasRecolectadas;
    public Text puntajeDeNivel;
    public Text Tiempo;



    void Update()
    {
        gotasRecolectadas.text = _controlJugador.Gotas.ToString();
        puntajeDeNivel.text = _controlJugador.puntaje.ToString();
    }
}
