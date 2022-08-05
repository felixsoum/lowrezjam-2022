using System;
using UnityEngine;

public class WorldSegment : MonoBehaviour
{
    [SerializeField] GameObject humanPrefab;
    [SerializeField] int humanMaxCount = 3;
    int humanCurrentCount;

    public void Spawn()
    {
        while (humanCurrentCount < 3)
        {
            humanCurrentCount++;
            var human = Instantiate(humanPrefab, CreateSpawnPos(), Quaternion.identity, transform);
            human.GetComponent<Human>().OwnerSegment = this;
        }
    }

    internal void OnHumanDeath()
    {
        humanCurrentCount--;
    }

    Vector3 CreateSpawnPos()
    {
        var pos = transform.position;
        pos.x += UnityEngine.Random.Range(-10f, 10f);
        pos.y = 1.82f;
        return pos;
    }

}
