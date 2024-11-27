using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CondicionDeVictoria : MonoBehaviour
{
    public bool puedePasarDeNivel;

    private void Update()
    {
        todosLosIncendiosApagados();
    }
    public void todosLosIncendiosApagados()
    {
        if (transform.childCount == 0)
        {
            Debug.Log("Puede pasar de Nivel");
            puedePasarDeNivel = true;
        }
    }
}
