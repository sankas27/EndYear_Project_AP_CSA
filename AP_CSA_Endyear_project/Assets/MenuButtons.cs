using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    public void LoadPuzzles()
    {
        SceneManager.LoadScene("Puzzles");
    }

    public void GoToStartScreen()
    {
        Debug.Log("Back to start clicked");
        SceneManager.LoadScene("Start_Screen");
    }

    public void LoadWinScreen()
    {
        SceneManager.LoadScene("Win_Screen");
    }

    public void LoadLoseScreen()
    {
        SceneManager.LoadScene("Lose_Screen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}