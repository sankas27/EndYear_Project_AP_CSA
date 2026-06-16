using UnityEngine;

public class WireManager : MonoBehaviour
{
    public BombGameManager gameManager;
    public Renderer statusLight;

    private Wire selectedWire;
    private bool solved = false;

    public void SelectWire(Wire wire)
    {
        if (solved) return;

        selectedWire = wire;
    }

    public void ConfirmAnswer()
    {
        if (solved || selectedWire == null) return;

        if (selectedWire.correctWire)
        {
            solved = true;

            selectedWire.transform.Rotate(0, 0, 45);

            if (statusLight != null)
                statusLight.material.color = Color.green;

            gameManager.PuzzleSolved();
        }
        else
        {
            gameManager.AddMistake();
            selectedWire = null;
        }
    }
}