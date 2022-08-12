using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : Enemy
{
    protected override void OnDeath()
    {
        if (OwnerSegment)
        {
            OwnerSegment.OnBuildingDeath();
        }
        base.OnDeath();
    }
}
