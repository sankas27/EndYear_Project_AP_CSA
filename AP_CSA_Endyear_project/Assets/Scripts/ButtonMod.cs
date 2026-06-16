using UnityEngine;
using TMPro;

public class ButtonMod : MonoBehaviour
{
    public BombGameManager gameManager;

    public Renderer statusLight;
    public Material redMat;
    public Material blueMat;
    public Material yellowMat;

    string[] colors = { "Red", "Blue", "Yellow" };
    public string buttonColor;

    public TextMeshPro labelText;
    string[] labels = { "ABORT", "PRESS", "HOLD", "DETONATE" };

    private Vector3 originalPosition;
    public int requiredPresses;
    private int currentPresses = 0;
    private bool solved = false;

    void Start()
    {
        originalPosition = transform.localPosition;

        buttonColor = colors[Random.Range(0, colors.Length)];
        string buttonLabel = labels[Random.Range(0, labels.Length)];
        labelText.text = buttonLabel;

        Renderer rend = GetComponent<Renderer>();

        if (buttonColor == "Red") rend.material = redMat;
        else if (buttonColor == "Blue") rend.material = blueMat;
        else rend.material = yellowMat;

        if (buttonColor == "Red" && buttonLabel == "ABORT") requiredPresses = 3;
        else if (buttonColor == "Blue" && buttonLabel == "DETONATE") requiredPresses = 5;
        else if (buttonColor == "Red" && buttonLabel == "PRESS") requiredPresses = 4;
        else if (buttonColor == "Yellow" && buttonLabel == "HOLD") requiredPresses = 7;
        else if (buttonColor == "Yellow" && buttonLabel == "PRESS") requiredPresses = 1;
        else requiredPresses = 2;
    }

    private void OnMouseDown()
    {
        if (solved) return;

        transform.localPosition = originalPosition + Vector3.down * 0.02f;
        currentPresses++;

        if (currentPresses == requiredPresses)
        {
            SolveModule();
        }
        else if (currentPresses > requiredPresses)
        {
            gameManager.AddMistake();
            currentPresses = 0;
        }

        Invoke(nameof(ResetButton), 0.1f);
    }

    private void ResetButton()
    {
        transform.localPosition = originalPosition;
    }

    void SolveModule()
    {
        if (solved) return;

        solved = true;
        statusLight.material.color = Color.green;
        gameManager.PuzzleSolved();
    }
}