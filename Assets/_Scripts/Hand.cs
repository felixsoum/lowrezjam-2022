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
            //ask if smashed button was pressed
            
            human.Die();
        }
    }
}
