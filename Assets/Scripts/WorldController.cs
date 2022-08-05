using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour
{
    [SerializeField] List<GameObject> worldSegments = new List<GameObject>();
    [SerializeField] CameraController cameraController;
    int segmentIndex;
    float segmentDistance;

    private void Awake()
    {
        segmentDistance = worldSegments[1].transform.position.x - worldSegments[0].transform.position.x;

        UpdateSegmentIndex();
    }

    private void UpdateSegmentIndex()
    {
        int closestIndex = 0;
        float closestDistance = 9999f;
        float cameraX = cameraController.transform.position.x;

        for (int i = 0; i < worldSegments.Count; i++)
        {
            float candidateDistance = Mathf.Abs(cameraX - worldSegments[i].transform.position.x);
            if (candidateDistance < closestDistance)
            {
                closestIndex = i;
                closestDistance = candidateDistance;
            }
        }
        segmentIndex = closestIndex;
    }

    private void Update()
    {
        if (segmentIndex == 0)
        {
            var temp = worldSegments[worldSegments.Count - 1];
            worldSegments.RemoveAt(worldSegments.Count - 1);
            temp.transform.position = worldSegments[0].transform.position + Vector3.left * segmentDistance;
            worldSegments.Insert(0, temp);
            segmentIndex++;
        }
        else if (segmentIndex == worldSegments.Count - 1)
        {
            var temp = worldSegments[0];
            temp.transform.position = worldSegments[worldSegments.Count - 1].transform.position + Vector3.right * segmentDistance;
            worldSegments.RemoveAt(0);
            worldSegments.Add(temp);
            segmentIndex--;
        }

        UpdateSegmentIndex();
    }
}
