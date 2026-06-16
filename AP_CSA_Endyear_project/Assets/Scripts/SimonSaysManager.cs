using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonManager : MonoBehaviour, IConfirmablePuzzle
{
    public BombGameManager gameManager;

    public Renderer blueButton;
    public Renderer greenButton;
    public Renderer redButton;
    public Renderer yellowButton;
    public Renderer statusLight;

    private List<SimonColor> sequence = new List<SimonColor>();
    private int currentInputIndex = 0;
    private bool canInput = false;
    private bool solved = false;

    private bool fullSequenceEntered = false;
    private bool madeMistake = false;

    public enum SimonColor { Blue, Green, Red, Yellow }

    private void Start()
    {
        AddRandomColor();
        StartCoroutine(PlaySequence());
    }

    void AddRandomColor()
    {
        sequence.Add((SimonColor)Random.Range(0, 4));
    }

    IEnumerator PlaySequence()
    {
        canInput = false;
        yield return new WaitForSeconds(1f);

        foreach (SimonColor color in sequence)
        {
            yield return StartCoroutine(FlashColor(color));
            yield return new WaitForSeconds(0.3f);
        }

        currentInputIndex = 0;
        fullSequenceEntered = false;
        madeMistake = false;
        canInput = true;
    }

    IEnumerator FlashColor(SimonColor color)
    {
        Renderer button = GetButton(color);
        Color originalColor = button.material.color;

        button.material.color = Color.white;
        yield return new WaitForSeconds(0.5f);
        button.material.color = originalColor;
    }

    Renderer GetButton(SimonColor color)
    {
        switch (color)
        {
            case SimonColor.Blue: return blueButton;
            case SimonColor.Green: return greenButton;
            case SimonColor.Red: return redButton;
            case SimonColor.Yellow: return yellowButton;
            default: return blueButton;
        }
    }

    IEnumerator PressAnimation(SimonColor color)
    {
        Renderer button = GetButton(color);
        Vector3 originalPos = button.transform.position;

        button.transform.position = originalPos + Vector3.down * 1.5f;
        yield return new WaitForSeconds(0.1f);
        button.transform.position = originalPos;
    }

    SimonColor GetExpectedColor(SimonColor flashedColor)
    {
        switch (flashedColor)
        {
            case SimonColor.Blue: return SimonColor.Red;
            case SimonColor.Red: return SimonColor.Blue;
            case SimonColor.Green: return SimonColor.Yellow;
            case SimonColor.Yellow: return SimonColor.Green;
            default: return flashedColor;
        }
    }

    public void PressBlue() { CheckInput(SimonColor.Blue); }
    public void PressGreen() { CheckInput(SimonColor.Green); }
    public void PressRed() { CheckInput(SimonColor.Red); }
    public void PressYellow() { CheckInput(SimonColor.Yellow); }

    public void CubePressed(SimonColor color)
    {
        CheckInput(color);
    }

    void CheckInput(SimonColor pressedColor)
    {
        if (solved || !canInput || fullSequenceEntered) return;

        StartCoroutine(PressAnimation(pressedColor));

        SimonColor expectedColor = GetExpectedColor(sequence[currentInputIndex]);

        if (pressedColor == expectedColor)
        {
            currentInputIndex++;

            if (currentInputIndex >= sequence.Count)
            {
                fullSequenceEntered = true;
                canInput = false;
                Debug.Log("Simon sequence entered. Press confirm.");
            }
        }
        else
        {
            madeMistake = true;
            fullSequenceEntered = true;
            canInput = false;
            Debug.Log("Simon wrong input. Press confirm.");
        }
    }

    public void ConfirmAnswer()
    {
        if (solved) return;

        if (madeMistake || !fullSequenceEntered)
        {
            if (gameManager != null)
                gameManager.AddMistake();

            ResetAnswer();
            return;
        }

        if (sequence.Count >= 4)
        {
            SolveModule();
        }
        else
        {
            AddRandomColor();
            StartCoroutine(PlaySequence());
        }
    }

    public void ResetAnswer()
    {
        sequence.Clear();
        AddRandomColor();
        StartCoroutine(PlaySequence());
    }

    void SolveModule()
    {
        if (solved) return;

        solved = true;
        canInput = false;

        if (statusLight != null)
            statusLight.material.color = Color.green;

        if (gameManager != null)
            gameManager.PuzzleSolved();
    }
}