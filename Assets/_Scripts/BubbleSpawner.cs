using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    public Transform parent;
    public GameObject bubblePrefab;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 0 is the left mouse button
        {
            SpawnBubbleAtMousePosition();
        }
    }

    void SpawnBubbleAtMousePosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z =  Camera.main.nearClipPlane;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        worldPosition.z = 0;
        GameObject bubble = Instantiate(bubblePrefab, worldPosition, Quaternion.identity, parent);
    }
}