using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int humanScore;
    int buildingsScore;

    public void AddHumanScore()
    {
        humanScore++;

    }
    public void AddBuildingScore()
    {
       buildingsScore++;

    }


    public int GetHumanScore()
    {
        return humanScore;
    }
    public int GetBuildingScore()
    {
        return buildingsScore;
    }

}
