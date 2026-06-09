using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimonSaysManager : MonoBehaviour{
    public enum SimonColor{Blue,Green,Red,Yellow};
    private List<SimonColor> sequence = new List<SimonColor>();
    public Image blueButton;
    public Image greenButton;
    public Image redButton;
    public Image yellowButton;
    private int currentInputIndex = 0;
    private bool canInput = false;
    private Color blue;
    private Color green;
    private Color red;
    private Color yellow;

    void Start(){
        blueNormal = blueButton.color;
        greenNormal = greenButton.color;
        redNormal = redButton.color;
        yellowNormal = yellowButton.color;

        AddRandomColor();
        StartCoroutine(PlaySequence());
    }

    void AddRandomColor(){
        sequence.Add((SimonColor)Random.Range(0, 4));
    }

    IEnumerator PlaySequence(){
        canInput = false;
        yield return new WaitForSeconds(1f);
        foreach (SimonColor color in sequence){
            yield return StartCoroutine(FlashColor(color));
            yield return new WaitForSeconds(0.3f);
        }
    }

    IEnumerator FlashColor(SimonColor color){
        yield return new WaitForSeconds(0.5f);
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
    void Update(){
        
    }
}
