using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var human = collision.GetComponent<Human>();
        if (human)
        {
            human.Die();
        }
    }
}
