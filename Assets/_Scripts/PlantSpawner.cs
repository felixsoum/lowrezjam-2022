using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSpawner : MonoBehaviour
{
    public GameObject curretChild;


    private void Start()
    {
        curretChild = GetComponentInChildren<Plants>().gameObject;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Invoke("ActivatingFlower", 3);
        }
    }

    private void ActivatingFlower()
    {
        curretChild.SetActive(true);
    }
}
