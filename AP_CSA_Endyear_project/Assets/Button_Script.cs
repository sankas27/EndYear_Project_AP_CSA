using UnityEngine;
using UnityEngine.UI;

public class Button_Script : MonoBehaviour
{
    public Button mainButton;
    public Renderer statusLight;
    public BombGameManager gameManager;

    public int requiredClicks = 5;

    private int clickCount = 0;
    private bool solved = false;

    public void ButtonPressed()
    {
        if (solved) return;

        clickCount++;
        Debug.Log("Clicks: " + clickCount);
    }

    public void ConfirmAnswer()
    {
        if (solved) return;

        if (clickCount == requiredClicks)
        {
            solved = true;
            Debug.Log("Correct!");

            if (statusLight != null)
                statusLight.material.color = Color.green;

            if (gameManager != null)
                gameManager.PuzzleSolved();
        }
        else
        {
            Debug.Log("Wrong! Resetting clicks.");

            if (gameManager != null)
                gameManager.AddMistake();

            ResetAnswer();
        }
    }

    public void ResetAnswer()
    {
        clickCount = 0;
        Debug.Log("Click count reset to 0.");
    }
}