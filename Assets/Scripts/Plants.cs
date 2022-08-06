using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plants : MonoBehaviour
{
    [SerializeField] Sprite noOutline;
    [SerializeField] Sprite withOutline;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = noOutline;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<Player>();
        if (player)
        {
            GetComponent<SpriteRenderer>().sprite = withOutline;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var player = collision.GetComponent<Player>();
        if (player)
        {
            GetComponent<SpriteRenderer>().sprite = noOutline;
        }
    }

}
