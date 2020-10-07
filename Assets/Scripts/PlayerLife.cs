using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    private Canvas gameOver;
    private GameObject panelGameOver;
    private Text playerWin;

    //variables de interfaz del personaje
    int vida;
    public int vidaMax;
    public Slider sliderVida;
    Animator anim;

    public AudioSource audioSourceImpacto;
    public AudioClip clipToPlay;

    private void Awake()
    {

        audioSourceImpacto.clip = clipToPlay;
        vida = vidaMax;
        sliderVida.maxValue = vidaMax;
        sliderVida.value = vida;
        anim = this.GetComponent<Animator>();

        gameOver = GameObject.Find("GameOverCanvas").GetComponent<Canvas>();
        panelGameOver = GameObject.Find("GameOverPanel");
        
    }
    private void Start()
    {
        panelGameOver.SetActive(false);
    }

    void RestarVida(int ataque)
    {


        audioSourceImpacto.Play();
        vida -= ataque;
        sliderVida.value = vida;
        if (vida <= 0)
        {
            panelGameOver.SetActive(true);

            panelGameOver = GameObject.Find("GameOverPanel");
            playerWin = panelGameOver.GetComponentInChildren<Text>();

            Time.timeScale = 0;
            
            if (this.tag == "Player1")
            {
                playerWin.text = "¡Gana el Jugador 2!";
            }
            else
            {
                playerWin.text = "¡Gana el Jugador 1!";
            }
        }
    }
}
