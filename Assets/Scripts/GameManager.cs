using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    private SpawnManager spawnManager;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartBtn;
    public GameObject titleScreen;

    public bool isGameActive = false;

    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateScore(int value)
    {
        score += value;
        scoreText.text = "Score : " + score;
    }

    public void StartGame()
    {
        this.isGameActive = true;
        this.scoreText.gameObject.SetActive(true);
        this.UpdateScore(0);
        this.titleScreen.gameObject.SetActive(false);
        this.spawnManager.StartSpawning();
    }

    public void GameOver()
    {
        this.isGameActive = false;
        this.gameOverText.gameObject.SetActive(true);
        this.restartBtn.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
