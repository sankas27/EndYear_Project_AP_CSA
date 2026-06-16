using UnityEngine;

public class Wire : MonoBehaviour
{
    public BombGameManager gameManager;

    public bool correctWire;
    private Vector3 originalScale;
    public Renderer statusLight;

    private bool solved = false;

    private void Start()
    {
        originalScale = transform.localScale;
    }

    private void OnMouseEnter()
    {
        if (!solved)
            transform.localScale = originalScale * 1.05f;
    }

    private void OnMouseExit()
    {
        transform.localScale = originalScale;
    }

    private void OnMouseDown()
    {
        if (solved) return;

        if (correctWire)
        {
            transform.Rotate(0, 0, 45);
            SolveModule();
        }
        else
        {
            gameManager.AddMistake();
        }
    }

    void SolveModule()
    {
        if (solved) return;

        solved = true;
        statusLight.material.color = Color.green;
        gameManager.PuzzleSolved();
    }
}