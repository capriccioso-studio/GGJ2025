using UnityEngine;
using Capriccioso;

public class BubbleSpawner : MonoSingleton<BubbleSpawner>
{
    public Transform parent;
    public GameObject bubblePrefab;
    public AudioClip bubbleSpawnSound;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 0 is the left mouse button
        {
            SpawnBubbleAtMousePosition();
        }
    }


    public void SpawnBubbleAtMousePosition()
    {
        if(GamePositionsReferences.Instance.player.RemainingBubbles <= 0)
        {
            return;
        }
        else
        {
            GamePositionsReferences.Instance.player.RemainingBubbles--;
            UIManager.Instance.gameplayUIHandler.SetBubblesText(GamePositionsReferences.Instance.player.RemainingBubbles);
        }
        
        GetComponent<AudioSource>().PlayOneShot(bubbleSpawnSound);

        Camera cam = Camera.main;
        Vector2 mousePosition = Input.mousePosition;
        Vector2 worldPosition = cam.ScreenToWorldPoint(mousePosition);
        Debug.Log($"mp: {mousePosition} | wp: {worldPosition}");

        GameObject bubble = Instantiate(bubblePrefab, worldPosition, Quaternion.identity);
    }
}