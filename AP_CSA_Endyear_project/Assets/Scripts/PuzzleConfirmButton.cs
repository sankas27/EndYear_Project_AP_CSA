using UnityEngine;

public class PuzzleConfirmButton : MonoBehaviour
{
    public GameObject puzzleObject;

    private void OnMouseDown()
    {
        if (puzzleObject == null)
        {
            Debug.LogError("No puzzle object assigned.");
            return;
        }

        Debug.Log("CONFIRM CLICKED: " + puzzleObject.name);
        puzzleObject.SendMessage("ConfirmAnswer", SendMessageOptions.DontRequireReceiver);
    }
}