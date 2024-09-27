using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{

    public ControlJugador _controlJugador;
    public GameObject[] PanelVidas0;
    public GameObject[] PanelVidas1;

    public Text gotasRecolectadas;

    void Start()
    {
     
    }


    void Update()
    {
        PuntajeGotas();
    }

    public void PuntajeGotas()
    {
        gotasRecolectadas.text = _controlJugador.Gotas.ToString();
    }

}
