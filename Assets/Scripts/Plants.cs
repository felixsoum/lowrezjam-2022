using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plants : MonoBehaviour
{
    [SerializeField] Sprite noOutline;
    [SerializeField] Sprite withOutline;
    [SerializeField] SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer.sprite = noOutline;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<Player>();
        if (player)
        {
            player.NearbyPlant = this;
            spriteRenderer.sprite = withOutline;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var player = collision.GetComponent<Player>();
        if (player)
        {
            player.NearbyPlant = null;
            spriteRenderer.sprite = noOutline;
        }
    }
}
