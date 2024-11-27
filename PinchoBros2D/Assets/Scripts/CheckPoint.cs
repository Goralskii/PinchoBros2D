using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public bool nivelCompletado = false;
    public CondicionDeVictoria _condicionDeVictoria;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(_condicionDeVictoria.puedePasarDeNivel == true)
            {
                GetComponent<Animator>().enabled = true;
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
                nivelCompletado = true;
            }
        }
    }
}
