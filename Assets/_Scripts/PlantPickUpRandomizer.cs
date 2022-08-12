using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantPickUpRandomizer : MonoBehaviour
{
    private void OnEnable()
    {
       transform.localPosition= new Vector3(UnityEngine.Random.Range(-10f, 10f),transform.position.y,0f);
    }
}
