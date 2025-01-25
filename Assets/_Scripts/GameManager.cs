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
        StartGame();
    }

    public void NextLevel()
    {
        currentLevel++;
        SceneManager.LoadScene("level_"+currentLevel);
        Restart("Level" + currentLevel);
    }
    
}
