using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{    
    [SerializeField] private int bestscore;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text currentScoreText;
    [SerializeField] private Text bestScoreText;
    [SerializeField] private GameObject statistics;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject startButton;
    [SerializeField] private GameObject menuButton;
    [SerializeField] private GameObject DifficultyToggles;
    [SerializeField] private AudioSource hitSound;
    [SerializeField] private AudioSource pointSound;


    private Player player;
    private Spawner spawner;

    public int score { get; private set; }

    private void Awake()
    {
        Application.targetFrameRate = 60;

        player = FindObjectOfType<Player>();
        spawner = FindObjectOfType<Spawner>();

        Pause();
        bestScoreText.text = PlayerPrefs.GetInt("score").ToString();      
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false);
        gameOver.SetActive(false);
        statistics.SetActive(false);
        startButton.SetActive(false);
        menuButton.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++) {
            Destroy(pipes[i].gameObject);
        }
    }

    public void GameOver()
    {
        hitSound.Play();
        playButton.SetActive(true);
        gameOver.SetActive(true);
        statistics.SetActive(true);
        menuButton.SetActive(true);
        SaveScore();
        Pause();
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
        pointSound.Play();
    }

    public void SaveScore()
    {
        scoreText.text = score.ToString();
        currentScoreText.text = score.ToString();
        bestscore = PlayerPrefs.GetInt("score");

        if (score > bestscore)
        {
            PlayerPrefs.SetInt("score", score);
            bestScoreText.text = score.ToString();
        }
        
    }

}
