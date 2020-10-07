using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectorPlayer_Script : MonoBehaviour
{

    public GameObject cool, beatiful, good, lapiz;
    private Vector2 characterPosition;
    private float characterCont;

    private readonly string selectedPlayer = "SelectedPlayer";
    private float num;

    public GameObject selectedPlayer1;
    public GameObject selectedPlayer2;

    public GameObject transicion;
    public AudioSource audioSourceSelectorPlayer;
    public AudioClip level1, clipToPlay, click;

    public Sprite coolSelect, beatifulSelect, goodSelect, lapizSelect;
    public Image imageToChange;

    public Button anterior, siguiente;

    void Awake()
    {
        characterPosition = cool.transform.position;
        characterCont = 1;
        num = 0;
        transicion.SetActive(false);
        selectedPlayer2.SetActive(false);
        audioSourceSelectorPlayer.clip = clipToPlay;
    }

    public void NextCharacter()
    {
        characterCont++;
        if (characterCont == 5)
        {
            characterCont = 1;
        }

        ChageCharacter(characterCont);
    }

    public void PreviusCharacter()
    {
        
        characterCont--;
        if (characterCont == 0)
        {
            characterCont = 4;
        }
        ChageCharacter(characterCont);
    }

    public void ChageCharacter(float characterCont)
    {
        
        audioSourceSelectorPlayer.clip = clipToPlay;
        audioSourceSelectorPlayer.Play();
        switch (characterCont)
        {
            case 1:
                cool.transform.position = characterPosition;
                cool.SetActive(true);
                beatiful.SetActive(false);
                good.SetActive(false);
                lapiz.SetActive(false);

                imageToChange.sprite = coolSelect;

                break;
            case 2:
                beatiful.transform.position = characterPosition;
                cool.SetActive(false);
                beatiful.SetActive(true);
                good.SetActive(false);
                lapiz.SetActive(false);

                imageToChange.sprite = beatifulSelect;

                break;
            case 3:

                good.transform.position = characterPosition;
                cool.SetActive(false);
                beatiful.SetActive(false);
                good.SetActive(true);
                lapiz.SetActive(false);

                imageToChange.sprite = goodSelect;

                break;
            case 4:

                lapiz.transform.position = characterPosition;
                cool.SetActive(false);
                beatiful.SetActive(false);
                good.SetActive(false);
                lapiz.SetActive(true);

                imageToChange.sprite = lapizSelect;

                break;
            default:
                break;
        }
    }

    void ChangeNavigation()
    {
        //Create a new navigation
        Navigation NewNavAnterior = new Navigation();
        NewNavAnterior.mode = Navigation.Mode.Explicit;

        //Set what you want to be selected on down, up, left or right;
        NewNavAnterior.selectOnUp = selectedPlayer2.GetComponent<Button>();
        NewNavAnterior.selectOnDown = selectedPlayer2.GetComponent<Button>();
        NewNavAnterior.selectOnLeft = siguiente;
        NewNavAnterior.selectOnRight = siguiente;

        //Assign the new navigation to your desired button or ui Object
        anterior.navigation = NewNavAnterior;

        //Create a new navigation
        Navigation NewNavSiguiente = new Navigation();
        NewNavSiguiente.mode = Navigation.Mode.Explicit;

        //Set what you want to be selected on down, up, left or right;
        NewNavSiguiente.selectOnUp = selectedPlayer2.GetComponent<Button>();
        NewNavSiguiente.selectOnDown = selectedPlayer2.GetComponent<Button>();
        NewNavSiguiente.selectOnLeft = anterior;
        NewNavSiguiente.selectOnRight = anterior;

        //Assign the new navigation to your desired button or ui Object
        siguiente.navigation = NewNavSiguiente;
    }
    public void SelectPlayer1()
    {

        audioSourceSelectorPlayer.clip = click;
        audioSourceSelectorPlayer.Play();

        selectedPlayer1.SetActive(false);
        selectedPlayer2.SetActive(true);
        EventSystem.current.SetSelectedGameObject(selectedPlayer2);

        ChangeNavigation();

        num = characterCont*10;
        characterCont = 1;

        ChageCharacter(characterCont);
    }

    public void SelectPlayer2()
    {
        audioSourceSelectorPlayer.clip = click;
        audioSourceSelectorPlayer.Play();

        num = num + characterCont;
        PlayerPrefs.SetFloat(selectedPlayer, num);

        StartGame();
    }

    public void StartGame()
    {
        AudioManager.Instance.PlayVoiceOver(level1);
        SceneManager.LoadScene("Level1");
    }
}
