using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BombGameManager : MonoBehaviour
{
    public int maxMistakes = 3;
    public int totalPuzzles = 4;

    public string loseSceneName = "Final_Screen";
    public string winSceneName = "Win_Screen";

    public TMP_Text mistakeText;

    private int mistakes = 0;
    private int puzzlesSolved = 0;

    public void AddMistake()
    {
        mistakes++;

        if (mistakeText != null)
            mistakeText.text = "Mistakes: " + mistakes + "/" + maxMistakes;

        if (mistakes >= maxMistakes)
            SceneManager.LoadScene(loseSceneName);
    }

    public void PuzzleSolved()
    {
        puzzlesSolved++;

        Debug.Log("Puzzles solved: " + puzzlesSolved + "/" + totalPuzzles);

        if (puzzlesSolved >= totalPuzzles)
            SceneManager.LoadScene(winSceneName);
    }
}