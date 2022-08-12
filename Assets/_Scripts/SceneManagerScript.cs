using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{



    public void LoadStartMenu()
    {
        StartCoroutine(LoadLevel("StartMenu"));
        FindObjectOfType<AudioManager>().ChangetoMenuMusic();

    }

     public void LoadFinalMenu()
    {
        StartCoroutine(LoadLevel("FinalScreen"));
        FindObjectOfType<AudioManager>().ChangetoMenuMusic();



    }

    public void LoadGame()
    {
        StartCoroutine(LoadLevel("Main"));
         FindObjectOfType<AudioManager>().ChangetoGameMusic();

    }



    IEnumerator LoadLevel(string levelName)
    {

        FindObjectOfType<LevelLoader>().LoadTransition();

        yield return new WaitForSeconds(FindObjectOfType<LevelLoader>().GetTransitionTime());

        yield return SceneManager.LoadSceneAsync(levelName);
        FindObjectOfType<LevelLoader>().FinishTransition();



        Time.timeScale = 1f;


    }
}
