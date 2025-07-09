using UnityEngine;
using TMPro;

public class timer : MonoBehaviour
{
    public float timeLeft = 20f;
    public TextMeshProUGUI timerText;
    public GameObject gameOverScreen; // ← Sleep hier je panel in via de Inspector
    public GameObject gameOverText; // ← optioneel extra tekst

    private bool isGameOver = false;

    void Update()
    {
        if (isGameOver) return;

        timeLeft -= Time.deltaTime;
        timeLeft = Mathf.Max(0, timeLeft);
        timerText.text = "Time: " + Mathf.CeilToInt(timeLeft);

        if (timeLeft <= 0)
        {
            TriggerGameOver();
        }
    }

    public void AddTime(float extra)
    {
        timeLeft += extra;
        timerText.text = "Time: " + Mathf.CeilToInt(timeLeft);
    }

    void TriggerGameOver()
    {
        isGameOver = true;
        Debug.Log("GAME OVER");

        gameOverScreen.SetActive(true); // maak het witte scherm zichtbaar

        gameOverText.SetActive(true);

        Time.timeScale = 0f; // Pauzeer de game (optioneel)
    }
}
