using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject gameOverScreen;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI newHighScoreText;

    public bool gameOver;
    public bool isPaused;
    public bool startPauseUsed = false;

    public int score = 0;
    public int lives = 3;
    public int livesMax = 3;
    public int highScore = 0;

    private void Awake()
    {
        // resets the timescale for restarts
        Time.timeScale = 1;

        // grabs saved startpauseused bool so that the pause screen only shows up at the start and not on restarts
        startPauseUsed = PlayerPrefs.GetInt("startpauseused") == 1 ? true : false;

        // pause at the start only the first time, not on restarts
        if (!startPauseUsed)
        {
            PauseAtStart();
        }
    }

    void Start()
    {
        // sets gameover bool to false at the start
        gameOver = false;

        // gets high score from previous game
        highScore = PlayerPrefs.GetInt("highscore", 0);

        // updates the score, lives, and high score UI
        scoreText.text = "Score: " + score;
        livesText.text = "Lives: " + lives;
        highScoreText.text = "High Score: " + highScore;
    }

    void Update()
    {
        GameOver();
        PauseGame();
    }

    // adds a point to the score and updates UI
    public void AddScore()
    {
        score++;

        // HACK: fix for the glitch where the multiples of ten have an extra digit (i.e. 10 becomes 110, 20 becomes 220, etc).
        if (score % 10 == 0)
        {
            scoreText.text = score.ToString("Score: 0");
        }
        else
        {
            scoreText.text = score.ToString("Score: " + score);
        }
    }

    // if the new score is higher than a previously saved one, the new score is saved as the high score
    public void SaveScore()
    {
        if (score > highScore)
        {
            PlayerPrefs.SetInt("highscore", score);
            PlayerPrefs.Save();
        }
    }

    // adds a life and updates UI, sets lives max at 3
    public void GainLife()
    {
        lives++;

        if (lives >= livesMax)
        {
            lives = livesMax;
        }

        livesText.text = lives.ToString("Lives: " + lives);
    }

    // removes a life and updates UI
    public void LoseLife()
    {
        lives--;
        livesText.text = lives.ToString("Lives: " + lives);
    }

    // opens the pause screen with instructions at the start of the game 
    public void PauseAtStart()
    {
        isPaused = true;
        pauseScreen.gameObject.SetActive(!pauseScreen.activeInHierarchy);

        startPauseUsed = true;
        PlayerPrefs.SetInt("startpauseused", startPauseUsed ? 1 : 0);
        PlayerPrefs.Save();

        Time.timeScale = 0;
    }

    // pauses and resumes the game when 'enter' is pressed
    public void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Return) && !gameOver)
        {
            if (isPaused)
            {
                Time.timeScale = 1;
                pauseScreen.gameObject.SetActive(!pauseScreen.activeInHierarchy);
                isPaused = false;
            }
            else if (!isPaused)
            {
                Time.timeScale = 0;
                pauseScreen.gameObject.SetActive(!pauseScreen.activeInHierarchy);
                isPaused = true;
            }
        }
    }

    // if the player loses all lives, game is over. If there is a new high score, it is saved and displayed
    public void GameOver()
    {
        if (lives == 0)
        {
            gameOver = true;
            SaveScore();
            gameOverScreen.gameObject.SetActive(true);

            if (score > highScore)
            {
                newHighScoreText.gameObject.SetActive(true);
                highScoreText.text = "High Score: " + score;
            }

            Time.timeScale = 0;
        }
    }

    // restarts the scene, attached to the RESTART button in UI
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

