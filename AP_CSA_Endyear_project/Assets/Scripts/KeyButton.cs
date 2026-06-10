using System.Collections;
using UnityEngine;

public class KeypadButton : MonoBehaviour
{
    public string symbol;
    public KeypadManager keypadManager;

    private Vector3 originalPos;

    void Start(){
        originalPos = transform.localPosition;
    }

    private void OnMouseDown(){
        StartCoroutine(PressAnimation());
        keypadManager.PressButton(symbol);
    }

    IEnumerator PressAnimation(){
        transform.localPosition = originalPos + Vector3.down * 0.1f;
        yield return new WaitForSeconds(0.1f);
        transform.localPosition = originalPos;
    }
}