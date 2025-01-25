using UnityEngine;
using Capriccioso;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{
    public int currentLevel;

    public void Start()
    {
        StartGame();
    }
    public void StartGame()
    {
        UIManager.Instance.ShowGameUI();
        Time.timeScale = 1;
    }

    public void Die()
    {
        UIManager.Instance.ShowGameOver();

        Time.timeScale = 0;
    }

    public void Restart(string scene)
    {
        GamePositionsReferences.Instance.player.transform.position = GamePositionsReferences.Instance.startPos.position;
        GamePositionsReferences.Instance.player.RemainingBubbles = GamePositionsReferences.Instance.player.BubbleCount; 
        UIManager.Instance.gameplayUIHandler.SetBubblesText(GamePositionsReferences.Instance.player.RemainingBubbles);

        StartGame();
    }

    public void NextLevel()
    {
        currentLevel++;
        Destroy(GamePositionsReferences.Instance.player.gameObject);
        SceneManager.LoadScene("level_"+currentLevel);
        UIManager.Instance.gameplayUIHandler.LevelText.text = $"Level {currentLevel}";
    }
    
}
