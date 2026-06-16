using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BombTimer : MonoBehaviour
{
    [Header("Timer Settings")]
    public float startTime = 60f;

    [Header("References")]
    public TMP_Text timerText;

    private float timeRemaining;
    private bool timerRunning = true;

    void Start()
    {
        timeRemaining = startTime;
        UpdateTimerDisplay();
    }

    void Update()
    {
        if (!timerRunning)
            return;

        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0)
        {
            timeRemaining = 0;
            timerRunning = false;
            TimerFinished();
        }

        UpdateTimerDisplay();
    }

    void UpdateTimerDisplay()
    {
        timerText.text = Mathf.CeilToInt(timeRemaining).ToString();
    }

    void TimerFinished()
    {
        timerText.text = "0";
        SceneManager.LoadScene("Final_Screen");
    }
}