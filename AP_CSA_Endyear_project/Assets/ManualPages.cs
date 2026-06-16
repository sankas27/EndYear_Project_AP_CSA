using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class ManualPages : MonoBehaviour
{
    public GameObject manualPanel;
    public TMP_Text manualText;

    public BombViewer bombViewer;

    private bool manualOpen = false;
    private int currentPage = 0;

    private string[] pages =
    {
        "BOMB MANUAL\n\nSPACE = open/close manual\nLEFT/RIGHT = change pages",

    "BUTTON WITH ARROWS\n\nIf it says DETONATE:\nPress UP 3 times, DOWN 1 time.\n\nIf it says DISARM:\nPress DOWN 2 times.\n\nIf it is yellow:\nPress UP 3 times.\n\nIf it is blue:\nPress DOWN 2 times.",

    "COLORED WIRES\n\nIf there are 3 wires of the same color:\nCut the 1st and 2nd wire.\n\nOtherwise, if the 2nd wire is blue or red:\nCut the 2nd wire.\n\nOtherwise, if there are any yellow wires:\nCut the 3rd and 5th wire.\n\nIf none apply:\nCut the 4th wire.",

    "BUTTON WITHOUT ARROWS\n\nRed + ABORT:\nPress 3 times.\n\nBlue + DETONATE:\nPress 5 times.\n\nRed + PRESS:\nPress 4 times.\n\nYellow + HOLD:\nPress 7 times.\n\nYellow + PRESS:\nPress 1 time.\n\nIf none apply:\nPress 2 times.",

    "KEYPAD\n\nClick the keypads in symbol priority order:\n\nΩ\nΦ\n★\nΨ\n∆\nΛ\n§\n©",

    "4 COLORED KEYPADS\n\nA random keypad will flash.\nPress the opposite color:\n\nBlue Flash → Press Red\nRed Flash → Press Blue\nGreen Flash → Press Yellow\nYellow Flash → Press Green\n\nMemorize a sequence of 4 buttons.\nIf you make a mistake, the sequence resets."
    };

    void Start()
    {
        manualPanel.SetActive(false);
        UpdatePage();
    }

    void Update()
    {
        if (Keyboard.current == null) return;

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            manualOpen = !manualOpen;
            manualPanel.SetActive(manualOpen);

            if (bombViewer != null)
                bombViewer.controlsEnabled = !manualOpen;

            UpdatePage();
        }

        if (!manualOpen) return;

        if (Keyboard.current.rightArrowKey.wasPressedThisFrame)
        {
            currentPage++;

            if (currentPage >= pages.Length)
                currentPage = pages.Length - 1;

            UpdatePage();
        }

        if (Keyboard.current.leftArrowKey.wasPressedThisFrame)
        {
            currentPage--;

            if (currentPage < 0)
                currentPage = 0;

            UpdatePage();
        }
    }

    void UpdatePage()
    {
        manualText.text = pages[currentPage] +
            "\n\nPage " + (currentPage + 1) + "/" + pages.Length +
            "\n\nSPACE = Close";
    }
}