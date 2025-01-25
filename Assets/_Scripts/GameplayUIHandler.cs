using TMPro;
using UnityEngine;

public class GameplayUIHandler : MonoBehaviour
{

    public TMP_Text RemainingBubblesText;
    
    public void Start()
    {
        SetBubblesText(Player.Instance.BubbleCount);
    }
    
    public void SetBubblesText(int remainingBubbles)
    {
        RemainingBubblesText.text = $"{remainingBubbles}";
        float t = Mathf.Clamp01((float)remainingBubbles / Player.Instance.BubbleCount);
        RemainingBubblesText.color = Color.Lerp(Color.red, Color.white, t);
    }

}
