using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonManager : MonoBehaviour
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

    public enum SimonColor { Blue, Green, Red, Yellow }

    private void Start()
    {
        AddRandomColor();
        StartCoroutine(PlaySequence());
    }

    void AddRandomColor()
    {
        SimonColor newColor = (SimonColor)Random.Range(0, 4);
        sequence.Add(newColor);
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
        if (solved || !canInput) return;

        StartCoroutine(PressAnimation(pressedColor));

        SimonColor expectedColor = GetExpectedColor(sequence[currentInputIndex]);

        if (pressedColor == expectedColor)
        {
            currentInputIndex++;

            if (currentInputIndex >= sequence.Count)
            {
                if (sequence.Count >= 4)
                {
                    SolveModule();
                    return;
                }

                canInput = false;
                AddRandomColor();
                StartCoroutine(PlaySequence());
            }
        }
        else
        {
            gameManager.AddMistake();

            sequence.Clear();
            AddRandomColor();
            StartCoroutine(PlaySequence());
        }
    }

    void SolveModule()
    {
        if (solved) return;

        solved = true;
        canInput = false;
        statusLight.material.color = Color.green;
        gameManager.PuzzleSolved();
    }
}