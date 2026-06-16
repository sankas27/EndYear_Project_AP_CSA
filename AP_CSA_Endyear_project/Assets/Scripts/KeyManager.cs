using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class KeyManager : MonoBehaviour
{
    public BombGameManager gameManager;

    string[] allSymbols = { "★", "Ω", "Ψ", "λ", "Φ", "∆", "§", "©" };
    string[] symbolPriority = { "Ω", "Φ", "★", "Ψ", "∆", "λ", "§", "©" };

    private string[] chosenSymbols;
    private string[] correctOrder;
    private int currentStep = 0;
    private bool solved = false;
    private bool wrongInput = false;

    public TextMeshPro key1Text;
    public TextMeshPro key2Text;
    public TextMeshPro key3Text;
    public TextMeshPro key4Text;

    public KeyButton key1Button;
    public KeyButton key2Button;
    public KeyButton key3Button;
    public KeyButton key4Button;

    public Renderer statusLight;

    void Start()
    {
        List<string> availableSymbols = new List<string>(allSymbols);
        chosenSymbols = new string[4];

        for (int i = 0; i < 4; i++)
        {
            int randomIndex = Random.Range(0, availableSymbols.Count);
            chosenSymbols[i] = availableSymbols[randomIndex];
            availableSymbols.RemoveAt(randomIndex);
        }

        key1Text.text = chosenSymbols[0];
        key2Text.text = chosenSymbols[1];
        key3Text.text = chosenSymbols[2];
        key4Text.text = chosenSymbols[3];

        key1Button.symbol = chosenSymbols[0];
        key2Button.symbol = chosenSymbols[1];
        key3Button.symbol = chosenSymbols[2];
        key4Button.symbol = chosenSymbols[3];

        key1Button.keypadManager = this;
        key2Button.keypadManager = this;
        key3Button.keypadManager = this;
        key4Button.keypadManager = this;

        correctOrder = new string[4];
        int orderIndex = 0;

        foreach (string prioritySymbol in symbolPriority)
        {
            foreach (string chosenSymbol in chosenSymbols)
            {
                if (prioritySymbol == chosenSymbol)
                {
                    correctOrder[orderIndex] = chosenSymbol;
                    orderIndex++;
                }
            }
        }
    }

    public void PressButton(string symbol)
    {
        if (solved) return;
        if (currentStep >= correctOrder.Length) return;

        if (!wrongInput && symbol == correctOrder[currentStep])
        {
            currentStep++;
        }
        else
        {
            wrongInput = true;
            currentStep++;
        }
    }

    public void ConfirmAnswer()
    {
        if (solved) return;

        if (!wrongInput && currentStep == correctOrder.Length)
        {
            SolveModule();
        }
        else
        {
            if (gameManager != null)
                gameManager.AddMistake();

            ResetAnswer();
        }
    }

    public void ResetAnswer()
    {
        currentStep = 0;
        wrongInput = false;
    }

    void SolveModule()
    {
        if (solved) return;

        solved = true;

        if (statusLight != null)
            statusLight.material.color = Color.green;

        if (gameManager != null)
            gameManager.PuzzleSolved();
    }
}