using TMPro;
using UnityEngine;

public class GameplayUIHandler : MonoBehaviour
{
    public AudioClip winSFX, loseSFX;
    public TMP_Text RemainingBubblesText;
    public TMP_Text LevelText;
    
    public void Start()
    {
        SetBubblesText(GamePositionsReferences.Instance.player.BubbleCount);
        LevelText.text = $"Level {GameManager.Instance.currentLevel}";
    }
    
    public void SetBubblesText(int remainingBubbles)
    {
        RemainingBubblesText.text = $"{remainingBubbles}";
        float t = Mathf.Clamp01((float)remainingBubbles / GamePositionsReferences.Instance.player.BubbleCount);
        RemainingBubblesText.color = Color.Lerp(Color.red, Color.white, t);
    }
    
    public void Win()
    {
        GetComponent<AudioSource>().PlayOneShot(winSFX);
    }
    
    public void Lose()
    {
        GetComponent<AudioSource>().PlayOneShot(loseSFX);
    }
    

}
