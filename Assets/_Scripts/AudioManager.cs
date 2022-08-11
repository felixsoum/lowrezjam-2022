using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip mainMenuMusic;
    [SerializeField] AudioClip gameplayMusic;

    

    AudioSource myAudio;

    private void Awake() 
    {
        myAudio =  GetComponent<AudioSource>();
    }

     public void ChangetoMenuMusic()
     {
        
       myAudio.clip = mainMenuMusic;
       myAudio.Play();

     }

     public void ChangetoGameMusic()
     {
        myAudio.clip = gameplayMusic;
        myAudio.Play();
     }
}
