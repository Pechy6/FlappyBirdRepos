using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameMenu : MonoBehaviour
{
    // Score 
    public TextMeshProUGUI ScoreText;
    [FormerlySerializedAs("score")] public int _score;

    // Escpape menu
    public TextMeshProUGUI FinalScoreText;
    public GameObject _menu;
    public static bool isPaused;

    // Game Over
    public GameObject _gameOver;

    void Start()
    {
        _menu.SetActive(false);
        _gameOver.SetActive(false);
        ScoreText.text = _score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        _menu.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }

    public void ResumeGame()
    {
        _menu.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }

    public void RestartGame()
    {
        ReloadScene.LoadLevel();
        isPaused = false;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void GameOver()
    {
        _gameOver.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }
}