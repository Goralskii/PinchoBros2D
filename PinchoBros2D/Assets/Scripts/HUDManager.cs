using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{

    public ControlJugador _controlJugador;
    public GameObject[] PanelVidas0;
    public GameObject[] PanelVidas1;

    void Start()
    {
        
    }


    void Update()
    {
        if (_controlJugador.FueraDeMapa == true)
        {
            ControlarVidas();
        }
    }

            

    private void ControlarVidas()
    {

        if (_controlJugador.Vidas >= 0)
        {
            PanelVidas1[_controlJugador.Vidas + 1].GetComponent<Image>().enabled = false;

        }
    }
}
