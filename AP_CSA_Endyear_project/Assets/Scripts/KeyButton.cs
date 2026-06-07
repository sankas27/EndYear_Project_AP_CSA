using UnityEngine;

public class KeypadButton : MonoBehaviour
{
    public string symbol;
    public KeypadManager manager;

    private void OnMouseDown()
    {
        manager.PressButton(symbol);
    }
}