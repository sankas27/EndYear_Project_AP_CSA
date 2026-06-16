using UnityEngine;

public class Wire : MonoBehaviour
{
    public WireManager wireManager;

    public bool correctWire;

    private Vector3 originalScale;

    private void Start()
    {
        originalScale = transform.localScale;
    }

    private void OnMouseEnter()
    {
        transform.localScale = originalScale * 1.05f;
    }

    private void OnMouseExit()
    {
        transform.localScale = originalScale;
    }

    private void OnMouseDown()
    {
        wireManager.SelectWire(this);

        Debug.Log(gameObject.name + " selected");
    }
}