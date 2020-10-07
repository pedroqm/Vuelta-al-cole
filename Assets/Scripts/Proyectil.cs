using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public int velocity;

    float posicionX;
    float posicionY;

    // hay que poner el numero contrario del jugador
    public int numPlayer;

    GameObject player;

    Vector3 posicionInicial;
    Vector3 posicionFinal;
    Vector3 directionTravel;

    private CameraShake cameraShake;
    public float duration, magnitude;

   
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("InicioDisparo" + numPlayer.ToString());
        posicionX = player.transform.position.x;
        posicionY = player.transform.position.y;
       
        cameraShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();

        posicionFinal = new Vector3(posicionX, posicionY, 0); // Vector del enemigo
        posicionInicial = this.transform.position; // Vector del Player

        directionTravel = posicionFinal - posicionInicial; // Calculamos el vector que tiene que seguir la bala para que vaya hacia la posicion del jugador
        directionTravel.Normalize();

        Invoke("DestoyProyectil", 4);
    }

    void DestoyProyectil()
    {
        Destroy(this.gameObject);
    }

    void Update()
    {


        DisparoDirigido();

    }


    void DisparoDirigido()
    {
        this.transform.Translate((directionTravel.x * velocity * Time.deltaTime), (directionTravel.y * velocity * Time.deltaTime), 0);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.CompareTag("Proyectil1") && collision.CompareTag("Player2"))
        {
            // quitar vida
            GameObject personaje = collision.GetComponent<Collider2D>().gameObject;
            personaje.SendMessage("RestarVida", 1);
            StartCoroutine(cameraShake.Shake(duration, magnitude));
        }
        if (this.CompareTag("Proyectil2") && collision.CompareTag("Player1"))
        {
            // quitar vida
            GameObject personaje = collision.GetComponent<Collider2D>().gameObject;
            personaje.SendMessage("RestarVida", 1);
            StartCoroutine(cameraShake.Shake(duration, magnitude));
        }
        if (!((this.CompareTag("Proyectil2") && collision.CompareTag("Player2")) || (this.CompareTag("Proyectil1") && collision.CompareTag("Player1"))))
        {
            Destroy(this.gameObject);
        }            
    }
}
