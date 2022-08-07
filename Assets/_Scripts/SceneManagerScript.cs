using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{



    public void LoadStartMenu()
    {
        StartCoroutine(LoadLevel("StartMenu"));



    }

    public void LoadGame()
    {
        StartCoroutine(LoadLevel("Main"));

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
