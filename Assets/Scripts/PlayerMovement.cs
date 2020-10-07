using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public int speed;
    public int numPlayer;

    bool pause; // variable para saber si el juego está en pausa

    string axisH, axisV;

    private float h, v;
    Animator anim;
    private GameObject flip;
    void Start()
    {
        anim = GetComponent<Animator>();
        axisH = "Horizontal" + numPlayer.ToString();
        axisV = "Vertical" + numPlayer.ToString();
       // flip = GameObject.FindGameObjectWithTag("Player" + numPlayer.ToString()).GetComponent<GameObject>();
    }

    private void FixedUpdate()
    {
        h = Input.GetAxis(axisH);
        v = Input.GetAxis(axisV);
        transform.Translate(Vector2.up * v * speed * Time.deltaTime);
        transform.Translate(Vector2.right * h * speed * Time.deltaTime);

        anim.SetFloat("velocidad" , Mathf.Abs(h) + Mathf.Abs(v));

        
    }

    void Flip()
    {
        if (h > 0)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        if (h < 0)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
    void Update()
    {


        //Flip();


        // esto poner mejor en el game manager
        if (Input.GetKeyDown(KeyCode.Escape)) // comprobamos si quiere pausar el juego
        {
            if (pause)
            {
                //canvasMenuPause.enabled = false;
                Time.timeScale = 1;
                pause = false;
            }
            else
            {
                //canvasMenuPause.enabled = true;
                Time.timeScale = 0;
                pause = true;
            }
        }

    }
}
