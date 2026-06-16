using UnityEngine;

public class CubeClick : MonoBehaviour
{
    public SimonManager simonManager;
    public SimonManager.SimonColor cubeColor;

    private void OnMouseDown()
    {
        simonManager.CubePressed(cubeColor);
    }
}