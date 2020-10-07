using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public int numPlayer;
    public float tiempoEsperaEntreDisparo;
    public GameObject InicioDisparo;
    [HideInInspector]
    public GameObject proyectil;
    

    public bool atacando; // variable para saber si el personaje está realizando la animación de ataque

    Animator anim;

    public AudioSource audioSourceDisparo;
    public AudioClip clipToPlay2;

    private void Awake()
    {
        audioSourceDisparo.clip = clipToPlay2;
    }


    void Start()
    {
        anim = GetComponent<Animator>();
        atacando = false;
    }

    void Update()
    {

        if (Input.GetButtonDown("Fire" + numPlayer.ToString())) // Disparamos si hay balas
        {
            Disparar();
        }
    }

    void Disparar()
    {
        audioSourceDisparo.Play();

        if (!atacando) // si está realizando la animacion atacando es true y no puede volver a atacar
                       //si atacando esta en false entra en el if
        {
            atacando = true;

            anim.SetBool("atacar", true);

            Invoke("DejarAtacar", tiempoEsperaEntreDisparo);

            Instantiate(proyectil, InicioDisparo.transform.position, transform.rotation);

        }
    }

    void DejarAtacar() // Deja de atacar
    {
        atacando = false;
        anim.SetBool("atacar", false);
    }
}
