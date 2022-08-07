using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plants : MonoBehaviour
{

    [SerializeField] SpriteRenderer spriteRenderer;

    [SerializeField] WeaponConfig weapon;
    BoxCollider2D myCollider;

    private void Start()
    {
        if (GetComponent<BoxCollider2D>().isActiveAndEnabled)
        {
            spriteRenderer.sprite = weapon.NotOutline();
            return;
        }

        spriteRenderer.sprite = weapon.WithOutline();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<Player>();
        if (player)
        {
            player.NearbyPlant = this;
            spriteRenderer.sprite = weapon.WithOutline();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var player = collision.GetComponent<Player>();
        if (player)
        {
            player.NearbyPlant = null;
            spriteRenderer.sprite = weapon.NotOutline();
        }
    }

    public WeaponConfig PickUp()
    {
        return weapon;
    }
}
