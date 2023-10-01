using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class gameManager : MonoBehaviour
{
    public GameOverDisplay GameOverDisplay;
    public TextMeshProUGUI ScoreText;
    public int Score;
    public Player Player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void GameOver()
    {
        Time.timeScale = 0.0f;
        GameOverDisplay.OnGameOver(Score);
    }
    public void RestartButtonCallback(int input)
    {
        // reset everything
        ResetGame();
        // resume time
        Time.timeScale = 1.0f;
    }
    private void ResetGame()
    {
        Player.Reset();
        ScoreText.text = "Score: 0";
        Score = 0;
        // reset Goomba
        GameOverDisplay.OnGameRestart();
    }
}
