using UnityEngine;

public class Human : Enemy
{
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] Sprite[] sprites;
    Vector3 patrolTarget;

    protected override void Awake()
    {
        patrolTarget = transform.localPosition;
        spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
        base.Awake();
    }

    protected override void Update()
    {
        if (Vector3.Distance(patrolTarget, transform.localPosition) < 0.01f)
        {
            patrolTarget.x = OwnerSegment.GetRandomOffsetX();
        }
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, patrolTarget, Time.deltaTime * moveSpeed);
        base.Update();
    }

    internal void SetSpriteOrder(int order)
    {
        spriteRenderer.sortingOrder = -order;
    }

    protected override void OnDeath()
    {
        if (OwnerSegment)
        {
            OwnerSegment.OnHumanDeath();
        }
        base.OnDeath();

        ScoreKeeper.AddHumanScore();
    }
}
