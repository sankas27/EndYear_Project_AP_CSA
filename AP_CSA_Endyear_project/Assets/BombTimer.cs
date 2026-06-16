using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BombTimer : MonoBehaviour
{
    [Header("Timer Settings")]
    public float startTimeMinutes = 5f;

    [Header("References")]
    public TMP_Text timerText;

    private float timeRemaining;
    private bool timerRunning = true;

    void Start()
    {
        timeRemaining = startTimeMinutes * 60f;
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

            UpdateTimerDisplay();

            SceneManager.LoadScene("Final_Screen");
            return;
        }

        UpdateTimerDisplay();
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);

        timerText.text = string.Format("{0}:{1:00}", minutes, seconds);
    }
}