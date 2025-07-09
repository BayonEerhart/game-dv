//resets de game als je gewonnen of game over bent


using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void RestartGame()
    {
        Time.timeScale = 1f; // Make sure time is running again
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
