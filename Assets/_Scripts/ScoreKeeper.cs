using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    static int score;

    public static void AddHumanScore(int humanScore = 1)
    {
        score += humanScore;
    }

    public static void AddBuildingScore(int buildingScore = 10)
    {
        score += 10;
    }

    public static int GetScore() => score;

    internal static void Reset()
    {
        score = 0;
    }
}
