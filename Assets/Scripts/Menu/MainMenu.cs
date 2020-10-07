using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{


    public AudioClip menu, level1;
    public GameObject transicion;
    public AudioSource audioSourceClick;
    public AudioClip clipToPlay;
    private void Awake()
    {
        audioSourceClick.clip = clipToPlay;
    }

    public void SelectPlayerScreen()
    {
        audioSourceClick.Play();
        transicion.SetActive(true);
        Invoke("LoadSceneSelectPlayerScreen", 1);

    }

    public void LoadSceneSelectPlayerScreen()
    {
        SceneManager.LoadScene("SelectPlayerScreen");
    }
    public void NuevaPartida()
    {
        audioSourceClick.Play();
        AudioManager.Instance.PlayVoiceOver(menu);
        SceneManager.LoadScene("SelectPlayerScreen");
        
    }

    public void Quit()
    {
        audioSourceClick.Play();
        Application.Quit();
    }

    public void Instructions()
    {
        audioSourceClick.Play();
        SceneManager.LoadScene("Instructions");
    }

    public void ComeBackToMainMenu()
    {
        audioSourceClick.Play();
        SceneManager.LoadScene("MainMenu");
    }

    /*  public void StartGame()
      {
          AudioManager.Instance.PlayVoiceOver(level1);
          SceneManager.LoadScene("Level1");

      }*/

}
