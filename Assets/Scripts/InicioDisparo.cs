using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InicioDisparo : MonoBehaviour
{

    public GameObject player;
    public GameObject inicioDisparo;
    void Start()
    {
        if (player.CompareTag("Player1"))
        {
            inicioDisparo.tag = "InicioDisparo1";
        }
        if (player.CompareTag("Player2"))
        {
            inicioDisparo.tag = "InicioDisparo2";
        }
    }

    
}
