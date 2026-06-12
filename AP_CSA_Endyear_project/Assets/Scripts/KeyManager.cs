using UnityEngine;
using TMPro;

public class KeypadManager : MonoBehaviour
{
    string[] allSymbols ={"★","Ω","Ψ","λ","Φ","∆","§","©"};
    string[] symbolPriority ={"Ω","Φ","★","Ψ","∆","λ","§","©"};
    private string[] chosenSymbols;
    private string[] correctOrder;
    private int currentStep = 0;
    public TextMeshPro key1Text;
    public TextMeshPro key2Text;
    public TextMeshPro key3Text;
    public TextMeshPro key4Text;
    public KeypadButton key1Button;
    public KeypadButton key2Button;
    public KeypadButton key3Button;
    public KeypadButton key4Button;
    public Renderer statusLight;

    void Start(){
        System.Collections.Generic.List<string> availableSymbols = new System.Collections.Generic.List<string>(allSymbols);
        chosenSymbols = new string[4];
        for (int i = 0; i < 4; i++){
            int randomIndex = Random.Range(0, availableSymbols.Count);
            chosenSymbols[i] = availableSymbols[randomIndex];
            availableSymbols.RemoveAt(randomIndex);
        }
        key1Text.text = chosenSymbols[0];
        key2Text.text = chosenSymbols[1];
        key3Text.text = chosenSymbols[2];
        key4Text.text = chosenSymbols[3];
        Debug.Log("Text1 = " + key1Text.text);
Debug.Log("Text2 = " + key2Text.text);
Debug.Log("Text3 = " + key3Text.text);
Debug.Log("Text4 = " + key4Text.text);
        key1Button.symbol = chosenSymbols[0];
        key2Button.symbol = chosenSymbols[1];
        key3Button.symbol = chosenSymbols[2];
        key4Button.symbol = chosenSymbols[3];
        correctOrder = new string[4];
        int orderIndex = 0;
        foreach (string prioritySymbol in symbolPriority){
            foreach (string chosenSymbol in chosenSymbols){
                if (prioritySymbol == chosenSymbol){
                    correctOrder[orderIndex] = chosenSymbol;
                    orderIndex++;
                }
            }
        }
    }
    void SolveModule(){
        Debug.Log("Module Solved!");
        statusLight.material.color = Color.green;
    }

    public void PressButton(string symbol){
    if (symbol == correctOrder[currentStep]){
        currentStep++;
        if (currentStep >= correctOrder.Length){
            SolveModule();
        }
    }
    else{
        Debug.Log("Strike!");
        currentStep = 0;
    }
}
}