using UnityEngine;

public class ConfirmObject : MonoBehaviour
{
    public MonoBehaviour puzzleScript;

    private void OnMouseDown()
    {
        IConfirmablePuzzle puzzle = puzzleScript as IConfirmablePuzzle;

        if (puzzle != null)
        {
            puzzle.ConfirmAnswer();
        }
        else
        {
            Debug.LogError("Assigned puzzle does not implement IConfirmablePuzzle.");
        }
    }
}