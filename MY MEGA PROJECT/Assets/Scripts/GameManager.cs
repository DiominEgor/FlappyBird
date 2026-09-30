using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button startButton;
    public Button restartButton;
    public GameObject bird;
    public GameObject spawnManager;
    public GameObject titleScreen;

    public GameObject dead;
    public bool isGameActive;
    private int score;

    public TextMeshProUGUI scoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        score = 0;
        scoreText.text = "Score: " + score;
        isGameActive = true;
        bird.SetActive(true);
        spawnManager.SetActive(true);
        titleScreen.SetActive(false);
        scoreText.gameObject.SetActive(true);
    }

    public void GameOver()
    {
        dead.SetActive(true);
        isGameActive = false;
        restartButton.gameObject.SetActive(true);

    }

    public void ScoreCount()
    {
        score += 1;
        scoreText.text = "Score: " + score;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
