using UnityEngine;

public class Human : MonoBehaviour
{
    [SerializeField] GameObject bloodEffect;
    public WorldSegment OwnerSegment { get; set; }

    internal void Die()
    {
        Instantiate(bloodEffect, transform.position, Quaternion.identity);
        OwnerSegment.OnHumanDeath();
        Destroy(gameObject);
    }
}
