using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEfecto : MonoBehaviour
{
    private Transform transformCamara;
    private Vector3 posicionPreviaCamara;
    [SerializeField] private float multiplicadorParallax;// 0.1f mas rapido, 0.9f mas lento
    
    //Lo que necesitamos saber para lograr el efecto parallax es saber cuanto se movio la camara entre 2 frames y aplicarles a las capaz una fraccion de ese movimiento
    void Start()
    {
        transformCamara = Camera.main.transform; //asigno componente transform de la camara principal
        posicionPreviaCamara = transformCamara.position;
    }

    
    void LateUpdate()//para asegurarnos de que este codigo se ejecute despues de que la cmara se haya movido
    {
        float deltaX = (transformCamara.position.x - posicionPreviaCamara.x) * multiplicadorParallax; // esta resta lo que nos da es cuanto se movio la camara en la coordenada X desde el frame anterior. 
        transform.Translate(new Vector3(deltaX, 0, 0));//para que cada una de nuestras capas se mueva en esa cantidad, en ese delta X
        posicionPreviaCamara = transformCamara.position;// esto es para que en el proximo frame pueda calcularse el nuevo delta X

    }
}
