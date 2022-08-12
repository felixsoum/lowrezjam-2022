using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuiButton : MonoBehaviour
{
     
    public void Quit()
    {
         FindObjectOfType<SceneManagerScript>().LoadFinalMenu();
    }
}
