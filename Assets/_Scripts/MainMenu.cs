using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI humanScore;
    [SerializeField] TextMeshProUGUI buildingScore;

    public void LoadGamePress()
    {
        FindObjectOfType<SceneManagerScript>().LoadGame();
    }
    private void Start()
    {
      if(humanScore != null)
      {
         humanScore.text = "x"+  FindObjectOfType<ScoreKeeper>().GetHumanScore().ToString();
      }
       if(buildingScore != null)
      {
         buildingScore.text = "x"+  FindObjectOfType<ScoreKeeper>().GetBuildingScore().ToString();
      }
    }
}
