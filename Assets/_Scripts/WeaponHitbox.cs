using UnityEngine;

public class WeaponHitbox : MonoBehaviour
{
    [SerializeField] Player player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            var enemy = collision.GetComponent<Enemy>();
            if (enemy)
            {
                player.OnWeaponHit(enemy);
            }
        }
    }
}
