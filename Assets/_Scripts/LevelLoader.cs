using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] Animator transition;
    [SerializeField] float transitionTime;

    public void LoadTransition()
    {

        transition.SetTrigger("FadeIn");

    }

    public void FinishTransition()
    {

        transition.SetTrigger("FadeOut");

    }


    public float GetTransitionTime()
    {
        return transitionTime;
    }
}
