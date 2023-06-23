using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenuScript : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;

    public void QuitGame()
    {
        Debug.Log("Quitting the game...");
        Application.Quit();
    }

    public void ResetGame()
    {
        gameManager.ResetGame();
    }
}
