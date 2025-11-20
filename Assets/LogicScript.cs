using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    private bool isGameOver = false;
    public AudioSource bulletSFX;

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        if (!isGameOver)
        {
            playerScore = playerScore + scoreToAdd;
            scoreText.text = playerScore.ToString();
            bulletSFX.Play();
        }
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
         gameOverScreen.SetActive(true);
         isGameOver = true;
    }
}
