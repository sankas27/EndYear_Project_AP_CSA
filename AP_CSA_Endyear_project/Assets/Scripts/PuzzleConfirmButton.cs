using UnityEngine;

public class PuzzleConfirmButton : MonoBehaviour
{
    public MonoBehaviour puzzleScript;

    public void ConfirmPressed()
    {
        IConfirmablePuzzle puzzle = puzzleScript as IConfirmablePuzzle;

        if (puzzle != null)
            puzzle.ConfirmAnswer();
        else
            Debug.LogError("This puzzle does not have ConfirmAnswer().");
    }
}