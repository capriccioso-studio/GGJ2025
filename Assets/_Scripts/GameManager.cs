using UnityEngine;
using Capriccioso;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{
    public int currentLevel;

    public void Start()
    {
        //GamePositionsReferences.Instance.player.GetComponent<ConstantForce2D>().force = new Vector2(0, 0);
    }
    public void StartGame()
    {
        GamePositionsReferences.Instance.player.rb2d.simulated = true;
        GamePositionsReferences.Instance.player.GetComponent<ConstantForce2D>().force = new Vector2(1, 0);

        UIManager.Instance.ShowGameUI();
        Time.timeScale = 1;
    }

    public void Die()
    {
        UIManager.Instance.ShowGameOver();
        UIManager.Instance.gameplayUIHandler.Lose();

        Time.timeScale = 0;
    }

    public void Restart(string scene)
    {
        //get all objects tagged player
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        //teleport all players
        foreach (GameObject player in players)
        {
            player.transform.position = GamePositionsReferences.Instance.startPos.position;
        }
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
        
        UIManager.Instance.gameplayUIHandler.Win();
    }

    public void Quit()
    {
            Application.Quit();
     }
    
}
