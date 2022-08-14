using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTime : MonoBehaviour
{
    [SerializeField] int startingTime = 120;
    [SerializeField] Image barForeground;
    float currentTime;
    private bool isGameFinished;

    private void Awake()
    {
        currentTime = startingTime;
    }

    private void Update()
    {
        currentTime -= Time.deltaTime;
        currentTime = Mathf.Max(currentTime, 0);
        if (!isGameFinished && currentTime <= 0)
        {
            isGameFinished = true;
            FindObjectOfType<SceneManagerScript>().LoadFinalMenu();
            return;
        }
        barForeground.transform.localScale = new Vector3(currentTime / startingTime, 1, 1);
    }
}
