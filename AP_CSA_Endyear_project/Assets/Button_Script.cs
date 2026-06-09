using UnityEngine;
using UnityEngine.UI;

public class Button_Script : MonoBehaviour
{
    public Button mainButton; 

    private int clickCount = 0;

    public void ButtonPressed()
    {
        clickCount++;

        Debug.Log("Clicks: " + clickCount);

        if (clickCount == 5)
        {
            ColorBlock colors = mainButton.colors;
            colors.normalColor = Color.green;
            colors.highlightedColor = Color.green;
            mainButton.colors = colors;
        }

        else if (clickCount > 5)
        {
            Debug.Log("Game Over");

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}