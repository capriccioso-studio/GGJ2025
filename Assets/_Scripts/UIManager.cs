using UnityEngine;
using Capriccioso;
using UnityEngine.SceneManagement;

public class UIManager : MonoSingleton<UIManager>
{

    public GameObject StartGameUI;
    public GameObject GameOverUI;
    public GameObject InGameUI;
    
    public GameplayUIHandler gameplayUIHandler;

    public void ShowMainMenu()
    {
        Debug.Log("ShowMainMenu");
    }

    public void ShowGameUI()
    {
        Debug.Log("ShowGameUI");
        StartGameUI.SetActive(false);
        GameOverUI.SetActive(false);
    }

    public void ShowGameOver()
    {
        Debug.Log("ShowGameOver");
        GameOverUI.SetActive(true);
    }
    

}