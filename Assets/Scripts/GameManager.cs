using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartBtn;

    public bool isGameActive = true;

    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {

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
        this.UpdateScore(0);
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
