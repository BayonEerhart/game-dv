using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;
public class SimplePlayerMovement : MonoBehaviour
{
    public GameObject gameOverScreen; // ← Sleep hier je panel in via de Inspector
    public GameObject gameWinText; // ← optioneel extra tekst
    public float moveSpeed = 5f;
    public float jumpForce = 2f;
    public timer timer;
    public gridspawner spawner;
    public TextMeshProUGUI scoreText; // ← Sleep hier je UI Text in via de Inspector
    private int score = 0;

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isGameOver = false;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        UpdateScoreText(); // start bij 0
    }

    void Update()
    {
        if (isGameOver) return;

        float moveX = 0f;
        if (Keyboard.current.aKey.isPressed) moveX = -1f;
        else if (Keyboard.current.dKey.isPressed) moveX = 1f;

        rb.linearVelocity = new Vector2(moveX * moveSpeed, rb.linearVelocity.y);

        if (Keyboard.current.spaceKey.wasPressedThisFrame && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            isGrounded = true;
            Debug.Log("Grounded");
        }

        if (other.CompareTag("Collectible"))
        {
            Debug.Log("coin collected");
            Destroy(other.gameObject);

            score += 1;
            UpdateScoreText();
            if (score >= 20)
            {
                TriggerGameWin();

            }
            timer.AddTime(1f);

            // Spawn een nieuwe coin
            spawner.SpawnCoin();
        }

    }

    // Ververst de tekst van de score
    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
        void TriggerGameWin()
    {
        isGameOver = true;
        Debug.Log("GAME WIN");

        gameOverScreen.SetActive(true); // maak het witte scherm zichtbaar

        gameWinText.SetActive(true);

        Time.timeScale = 0f; // Pauzeer de game (optioneel)
    }
}
