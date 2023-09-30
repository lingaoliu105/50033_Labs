using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{

    public UnityEvent gameStart;
    public UnityEvent gameReset;
    public UnityEvent<int> scoreChange;
    public UnityEvent<int> gameOver;

    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameStart.Invoke();
        Time.timeScale = 1.0f;
    }

    public void GameOver()
    {
        Time.timeScale = 0.0f;
        gameOver.Invoke(score);
    }

    public void RestartButtonCallback(int input)
    {
        ResetGame();
    }

    void SetScore(int score)
    {
        this.score = score;
        scoreChange.Invoke(score);
    }

    public void IncreaseScore(int increment)
    {
        SetScore(score+increment);
    }
    private void ResetGame()
    {
        SetScore(0);        
        gameReset.Invoke();
        Time.timeScale = 1.0f;
    }
}
