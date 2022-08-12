using System;
using UnityEngine;

public class WorldSegment : MonoBehaviour
{
    [SerializeField] GameObject humanPrefab;
    [SerializeField] GameObject buildingPrefab;
    [SerializeField] int humanMaxCount = 3;
    int humanCurrentCount;
    bool isBuildingAlive;

    public void Spawn()
    {
        while (humanCurrentCount < 3)
        {
            humanCurrentCount++;
            var human = Instantiate(humanPrefab, CreateSpawnPos(1.82f), Quaternion.identity, transform);
            human.GetComponent<Human>().OwnerSegment = this;
        }

        if (!isBuildingAlive)
        {
            isBuildingAlive = true;
            var building = Instantiate(buildingPrefab, CreateSpawnPos(2.82f), Quaternion.identity, transform);
            building.GetComponent<Building>().OwnerSegment = this;
        }
    }

    internal void OnHumanDeath()
    {
        humanCurrentCount--;
    }

    internal void OnBuildingDeath()
    {
        isBuildingAlive = false;
    }

    Vector3 CreateSpawnPos(float y)
    {
        var pos = transform.position;
        pos.x += UnityEngine.Random.Range(-10f, 10f);
        pos.y = y;
        return pos;
    }

}
