using UnityEngine;
using UnityEngine.SceneManagement;

public class Wire : MonoBehaviour
{
    public Timer timer;
    public bool correctWire;
    private bool alreadyCut = false;
    private static int mistakes = 0;
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
        if (correctWire)
        {
            timer.bombDefused = true;
            transform.Rotate(0, 0, 45);
            Debug.Log("Bomb Defused");
        }
        else
        {
            mistakes++;

            Debug.Log("Mistakes: " + mistakes + "/3");

            if (mistakes >= 3)
            {
                Debug.Log("LOADING FINAL SCREEN");
                SceneManager.LoadScene("Final_Screen");
            }
        }
    }
}
