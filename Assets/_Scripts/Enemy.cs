using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] GameObject deathPrefab;
    [SerializeField] int maxHp = 6;

    public WorldSegment OwnerSegment { get; set; }

    Material material;
    float hitValue;
    protected int hp;

    protected virtual void Awake()
    {
        material = spriteRenderer.material;
        hp = maxHp;
    }

    private void Update()
    {
        if (hitValue > 0)
        {
            hitValue = Mathf.Clamp01(hitValue - Time.deltaTime * 5f);
            material.SetFloat("_HitValue", hitValue);
        }
    }

    public virtual void Damage(int damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            Instantiate(deathPrefab, transform.position, Quaternion.identity);
            OnDeath();
        }
        else
        {
            hitValue = 1f;
            material.SetFloat("_HitValue", hitValue);
        }
    }

    protected virtual void OnDeath()
    {
        Destroy(gameObject);
    }
}
