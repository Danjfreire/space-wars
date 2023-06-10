using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;

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
    }
}
