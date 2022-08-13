using UnityEngine;

public class WorldSegment : MonoBehaviour
{
    [SerializeField] GameObject humanPrefab;
    [SerializeField] GameObject buildingPrefab;
    [SerializeField] int humanMaxCount = 3;
    int humanCurrentCount;
    int humanSpriteOrder;
    bool isBuildingAlive;

    public void Spawn()
    {
        while (humanCurrentCount < 3)
        {
            humanCurrentCount++;
            var human = Instantiate(humanPrefab, CreateSpawnPos(1.94f), Quaternion.identity, transform).GetComponent<Human>();
            human.OwnerSegment = this;
            humanSpriteOrder %= 3;
            human.SetSpriteOrder(humanSpriteOrder);
            humanSpriteOrder++;
        }

        if (!isBuildingAlive)
        {
            isBuildingAlive = true;
            var building = Instantiate(buildingPrefab, CreateSpawnPos(3.9f), Quaternion.identity, transform);
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
        pos.x += GetRandomOffsetX();
        pos.y = y;
        return pos;
    }

    public float GetRandomOffsetX() => UnityEngine.Random.Range(-10f, 10f);

}
