// dit scriptje maakt het dat je de timer kan gebruiken en dat het af teld 
// en als je 0 seconde over hebt dan opent het de game over screen


using UnityEngine;
using TMPro;

public class timer : MonoBehaviour
{
    public float timeLeft = 20f;
    public TextMeshProUGUI timerText;
    public GameObject gameOverScreen;
    public GameObject gameOverText;

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
