using UnityEngine;
using TMPro;

public class ButtonMod : MonoBehaviour{
    public Renderer statusLight;
    public Material redMat;
    public Material blueMat;
    public Material yellowMat;
    string[] colors = {"Red", "Blue", "Yellow" };
    public string buttonColor;

    public TextMeshPro labelText;
    string[] labels = {"ABORT","PRESS","HOLD","DETONATE"};

    private Vector3 originalPosition;

    public int requiredPresses;

    private int currentPresses = 0;

    void Start(){
        originalPosition = transform.localPosition;
        int randomIndex = Random.Range(0, colors.Length);
        buttonColor = colors[randomIndex];

        Renderer rend = GetComponent<Renderer>();

        int randomLabel = Random.Range(0, labels.Length);
        string buttonLabel = labels[randomLabel];
        labelText.text = buttonLabel;

        if (buttonColor == "Red"){
            rend.material = redMat;
            requiredPresses = 3;
        }
        else if (buttonColor == "Blue"){
            rend.material = blueMat;
            requiredPresses = 5;
        }
        else{
            rend.material = yellowMat;
            requiredPresses = 2;
        }
        if (buttonColor == "Red" && buttonLabel == "ABORT"){
            requiredPresses = 3;
        }
        else if (buttonColor == "Blue" && buttonLabel == "DETONATE"){
            requiredPresses = 5;
        }
        else if(buttonColor == "Red" && buttonLabel == "PRESS"){
            requiredPresses = 4;
        }
        else if (buttonColor == "Yellow" && buttonLabel == "HOLD"){
            requiredPresses = 7;
        }
        else if(buttonColor == "Yellow" && buttonLabel == "PRESS"){
            requiredPresses = 1;
        }
        else{
            requiredPresses = 2;
        }   

        Debug.Log("Button Color: " + buttonColor);
        Debug.Log("Required Presses: " + requiredPresses);
    }

    private void OnMouseDown(){
        transform.localPosition = originalPosition + Vector3.down * 0.02f;
        currentPresses++;

        Debug.Log("Presses: " + currentPresses);

        if (currentPresses == requiredPresses){
            SolveModule();
        }

        if (currentPresses > requiredPresses){
            Debug.Log("Incorrect");
        }
            
        Invoke(nameof(ResetButton), 0.1f);
    }
    private void ResetButton(){
        transform.localPosition = originalPosition;
    }   
    void SolveModule(){
        Debug.Log("Module Solved!");
        statusLight.material.color = Color.green;
    }
}