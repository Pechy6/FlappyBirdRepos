using UnityEngine;

public class Score : MonoBehaviour
{
    private AudioSource _audioSource;
    private GameObject _gameManager;
    private GameMenu _gameMenu;
    public int completeScore;
 
    private void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameManager");
        _gameMenu = _gameManager.GetComponent<GameMenu>();
        _audioSource = GameObject.FindGameObjectWithTag("Points").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            _gameMenu.GameOver();
            _gameMenu.FinalScoreText.text = completeScore.ToString();
        }
        else
        {
            _gameMenu._score++;
            completeScore = _gameMenu._score;
            _gameMenu.ScoreText.text = _gameMenu._score.ToString();
            _audioSource.Play();
        }
       
    }
}
