using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonManager : MonoBehaviour
{
    public Renderer blueButton;
    public Renderer greenButton;
    public Renderer redButton;
    public Renderer yellowButton;
    private List<SimonColor> sequence = new List<SimonColor>();
    private int currentInputIndex = 0;
    private bool canInput = false;
    public Renderer statusLight;

    private void Start(){
        AddRandomColor();
        StartCoroutine(PlaySequence());
    }

    public enum SimonColor{Blue,Green,Red,Yellow};

    void AddRandomColor(){
        SimonColor newColor = (SimonColor)Random.Range(0, 4);
        sequence.Add(newColor);
        Debug.Log("Added color: " + newColor);
    }

    IEnumerator PlaySequence(){
        canInput = false;

        Debug.Log("Playing sequence...");

        yield return new WaitForSeconds(1f);

        foreach (SimonColor color in sequence){
            yield return StartCoroutine(FlashColor(color));
            yield return new WaitForSeconds(0.3f);
        }

    currentInputIndex = 0;
    canInput = true;

    Debug.Log("Waiting for player input.");
    }

    IEnumerator FlashColor(SimonColor color){
        Renderer button = GetButton(color);
        Color originalColor = button.material.color;
        button.material.color = Color.white;
        yield return new WaitForSeconds(0.5f);
        button.material.color = originalColor;
    }

    Renderer GetButton(SimonColor color){
        switch (color){
            case SimonColor.Blue:
            return blueButton;

            case SimonColor.Green:
            return greenButton;

            case SimonColor.Red:
            return redButton;

            case SimonColor.Yellow:
            return yellowButton;

            default:
            return blueButton;
        }
    }
    IEnumerator PressAnimation(SimonColor color){
        Renderer button = GetButton(color);
        Vector3 originalPos = button.transform.position;
        button.transform.position = originalPos + Vector3.down * 1.5f;  
        yield return new WaitForSeconds(0.1f);
        button.transform.position = originalPos;
}

    SimonColor GetExpectedColor(SimonColor flashedColor){
    switch (flashedColor){
        case SimonColor.Blue:
            return SimonColor.Red;

        case SimonColor.Red:
            return SimonColor.Blue;

        case SimonColor.Green:
            return SimonColor.Yellow;

        case SimonColor.Yellow:
            return SimonColor.Green;

        default:
            return flashedColor;
        }
    }

    public void PressBlue(){
        CheckInput(SimonColor.Blue);
    }

    public void PressGreen(){
        CheckInput(SimonColor.Green);
    }

    public void PressRed(){
        CheckInput(SimonColor.Red);
    }

    public void PressYellow(){
        CheckInput(SimonColor.Yellow);
    }
    public void CubePressed(SimonColor color){
        CheckInput(color);
    }

    void CheckInput(SimonColor pressedColor){
        StartCoroutine(PressAnimation(pressedColor));
         if (!canInput){
            Debug.Log("Input ignored - sequence is playing.");
            return;
        }
        SimonColor expectedColor =
        GetExpectedColor(sequence[currentInputIndex]);
        Debug.Log("Player pressed: " + pressedColor);
        Debug.Log("Flashed: " + sequence[currentInputIndex]);
        Debug.Log("Expected: " + expectedColor);
        if (pressedColor == expectedColor)
{
    currentInputIndex++;
    Debug.Log("Correct!");

    if (currentInputIndex >= sequence.Count)
    {
        if (sequence.Count >= 4)
    {
            SolveModule();
        return;
    }
        Debug.Log("Round Complete!");
        canInput = false;
        AddRandomColor();
        StartCoroutine(PlaySequence());
    }
}
else
{
    Debug.Log("Wrong!");
    sequence.Clear();
    AddRandomColor();
    StartCoroutine(PlaySequence());
}
void SolveModule(){
    Debug.Log("Module Solved!");
    statusLight.material.color = Color.green;
}
}
}