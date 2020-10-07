using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    
    public GameObject cool, beatiful, good, lapiz, player1, player2, character1, character2;
    private Vector2 characterPositionPlayer1;
    private Vector2 characterPositionPlayer2;
    public GameObject proyectil1, proyectil2;

    public float velocidadDisparoCool, velocidadDisparoBeautiful, velocidadDisparoGood, velocidadDisparoLapiz;
    public int velocidadMovimientoCool, velocidadMovimientoBeautiful, velocidadMovimientoGood, velocidadMovimientoLapiz;
    public int hpCharacterCool, hpCharacterBeautiful, hpCharacterGood, hpCharacterLapiz;

    private float velocidadDisparo;
    private int velocidadMovimiento, hpCharacter;
    private float playerSelected;
    private readonly string selectedPlayer = "SelectedPlayer";

    private void Awake()
    {
        Time.timeScale = 1;

        characterPositionPlayer1 = player1.transform.position;
        characterPositionPlayer2 = player2.transform.position;


        playerSelected = PlayerPrefs.GetFloat(selectedPlayer);


        int selectedPlayer1 = (int)playerSelected / 10;
        int selectedPlayer2 = (int) playerSelected - (selectedPlayer1 *10);


        LoadPlayer(selectedPlayer1, player1, character1, 1, proyectil1);
        LoadPlayer(selectedPlayer2, player2, character2, 2, proyectil2);
    }

    public void LoadPlayer(int characterCont, GameObject player, GameObject _character, int numPlayer, GameObject proyectil)
    {
        GameObject character;
        switch (characterCont)
        {
            case 1:
                // COOL
                character = Instantiate(cool);
                velocidadDisparo = velocidadDisparoCool;
                hpCharacter = hpCharacterCool;
                velocidadMovimiento = velocidadMovimientoCool;

                break;
            case 2:
                // BEAUTIFUL             
                character = Instantiate(beatiful);
                velocidadDisparo = velocidadDisparoBeautiful;
                hpCharacter = hpCharacterBeautiful;
                velocidadMovimiento = velocidadMovimientoBeautiful;

                break;
            case 3:
                // GOOD
                character = Instantiate(good);
                velocidadDisparo = velocidadDisparoGood;
                hpCharacter = hpCharacterGood;
                velocidadMovimiento = velocidadMovimientoGood;

                break;
            case 4:
                // LAPIZ
                character = Instantiate(lapiz);
                velocidadDisparo = velocidadDisparoLapiz;
                hpCharacter = hpCharacterLapiz;
                velocidadMovimiento = velocidadMovimientoLapiz;

                break;
            default:
                character = player;
                break;
        }
        
        character.transform.SetParent(player.transform);
        character.GetComponent<PlayerAttack>().tiempoEsperaEntreDisparo = velocidadDisparo;
        character.GetComponent<PlayerAttack>().proyectil = proyectil;
        character.GetComponent<PlayerAttack>().numPlayer = numPlayer;
        character.GetComponent<PlayerLife>().vidaMax = hpCharacter;
        character.GetComponent<PlayerMovement>().speed = velocidadMovimiento;
        character.GetComponent<PlayerMovement>().numPlayer = numPlayer;
        if (numPlayer == 2)
        {
            character.transform.position = new Vector2(-30f, 0f);
        }
        
        character.tag = "Player" + numPlayer.ToString();

    }

}
