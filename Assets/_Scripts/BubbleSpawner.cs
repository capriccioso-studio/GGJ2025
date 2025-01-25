using UnityEngine;
using Capriccioso;

public class BubbleSpawner : MonoSingleton<BubbleSpawner>
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


    public void SpawnBubbleAtMousePosition()
    {
        if(Player.Instance.RemainingBubbles <= 0)
        {
            return;
        }
        else
        {
            Player.Instance.RemainingBubbles--;
            UIManager.Instance.gameplayUIHandler.SetBubblesText(Player.Instance.RemainingBubbles);
        }

        Camera cam = Camera.main;
        Vector2 mousePosition = Input.mousePosition;
        Vector2 worldPosition = cam.ScreenToWorldPoint(mousePosition);
        Debug.Log($"mp: {mousePosition} | wp: {worldPosition}");

        GameObject bubble = Instantiate(bubblePrefab, worldPosition, Quaternion.identity);
    }
}