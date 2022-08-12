using UnityEngine;

public class Human : Enemy
{
    protected override void OnDeath()
    {
        if (OwnerSegment)
        {
            OwnerSegment.OnHumanDeath(); 
        }
        base.OnDeath();
         FindObjectOfType<ScoreKeeper>().AddHumanScore();
    }
}
