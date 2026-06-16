using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MistakeManager : MonoBehaviour
{
    public int maxMistakes = 3;
    public int currentMistakes = 0;

    public TMP_Text mistakeText;
    public string loseSceneName = "Final_Screen";

    public void AddMistake()
    {
        currentMistakes++;

        Debug.Log("Mistakes: " + currentMistakes + "/" + maxMistakes);

        if (mistakeText != null)
            mistakeText.text = "Mistakes: " + currentMistakes + "/" + maxMistakes;

        if (currentMistakes >= maxMistakes)
        {
            SceneManager.LoadScene(loseSceneName);
        }
    }
}