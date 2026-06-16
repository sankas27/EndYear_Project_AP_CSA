using UnityEngine;
using UnityEngine.SceneManagement;

public class BombGameManager : MonoBehaviour
{
    [Header("Game Settings")]
    public int totalPuzzles = 5;

    [Header("Strike Indicators")]
    public Renderer strike1;
    public Renderer strike2;
    public Renderer strike3;

    private int puzzlesSolved = 0;
    private int mistakes = 0;

    void Start()
    {
        if (strike1 != null)
            strike1.material.color = Color.black;

        if (strike2 != null)
            strike2.material.color = Color.black;

        if (strike3 != null)
            strike3.material.color = Color.black;
    }

    public void PuzzleSolved()
    {
        puzzlesSolved++;

        Debug.Log("Puzzles Solved: " + puzzlesSolved + "/" + totalPuzzles);

        if (puzzlesSolved >= totalPuzzles)
        {
            SceneManager.LoadScene("Win_Screen");
        }
    }

    public void AddMistake()
    {
        mistakes++;

        Debug.Log("Mistakes: " + mistakes);

        if (mistakes >= 1 && strike1 != null)
            strike1.material.color = Color.red;

        if (mistakes >= 2 && strike2 != null)
            strike2.material.color = Color.red;

        if (mistakes >= 3 && strike3 != null)
            strike3.material.color = Color.red;

        if (mistakes >= 3)
        {
            Debug.Log("Too many mistakes!");

            SceneManager.LoadScene("Lose_Screen");
        }
    }
}