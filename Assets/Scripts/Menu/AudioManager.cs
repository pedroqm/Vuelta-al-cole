using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;
    public AudioClip menu;
    public AudioSource voiceOver;

    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("AudioManager is null!");
            }

            return _instance;
        }
    }

   

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            PlayVoiceOver(menu);
            DontDestroyOnLoad(this.gameObject);
           
        }

       
        
    }

    public void PlayVoiceOver(AudioClip clipToPlay)
    {
        voiceOver.clip = clipToPlay;
        voiceOver.Play();
    }

    
}
