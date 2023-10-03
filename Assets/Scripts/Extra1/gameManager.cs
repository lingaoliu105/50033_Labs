using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class gameManager : MonoBehaviour
{
    public GOscreen GOscreen;
    public TextMeshProUGUI ScoreText;
    public float Score;
    public Player Player;
    private float MaxScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        float tmp = Player.transform.position.y;
        DisplayScore(tmp);
    }

    // Update is called once per frame
    void Update()
    {
        DisplayScore(Player.transform.position.y);
    }
    public void GameOver()
    {
        Time.timeScale = 0.0f;
        GOscreen.OnGameOver(MaxScore);
    }
    public void RestartButtonCallback(int input)
    {
        // reset everything
        ResetGame();
        // resume time
        Time.timeScale = 1.0f;
    }

    private void DisplayScore(float cur)
    {
        MaxScore = Mathf.Max(MaxScore, cur);
        ScoreText.text = "Score: " + Mathf.Round(MaxScore);
    }

    private void ResetGame()
    {
        Player.Reset();
        ScoreText.text = "Score: 0";
        Score = 0;
        GOscreen.OnGameRestart();
    }
}
