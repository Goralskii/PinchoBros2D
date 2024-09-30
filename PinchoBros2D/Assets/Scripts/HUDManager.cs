using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{

    public ControlJugador _controlJugador;
    public GameManager gameManager;

    public GameObject[] PanelVidas0;
    public GameObject[] PanelVidas1;

    public Text gotasRecolectadas;

    public Text puntajeDeNivel;

    public Text Tiempo;


    void Start()
    {
     
    }


    void Update()
    {
        gotasRecolectadas.text = _controlJugador.Gotas.ToString();
        puntajeDeNivel.text = _controlJugador.puntaje.ToString();
        Tiempo.text = gameManager.tiempo.ToString();

    }
}
