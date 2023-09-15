using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameOverDisplay GameOverDisplay;

    public PlayerMovement MarioMovement;

    public TextMeshProUGUI ScoreText;

    public JumpOverGoomba JumpOverGoomba;

    public GameObject enemies;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("game manager start");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        GameOverDisplay.OnGameOver(JumpOverGoomba.Score);
    }
    
    public void RestartButtonCallback(int input)
    {
        Debug.Log("Restart!");
        // reset everything
        ResetGame();
        // resume time
        Time.timeScale = 1.0f;
    }

    private void ResetGame()
    {
        MarioMovement.Reset();
        ScoreText.text = "Score: 0";
        JumpOverGoomba.Score = 0;
        // reset Goomba
        foreach (Transform eachChild in enemies.transform)
        {
            eachChild.transform.localPosition = eachChild.GetComponent<EnemyMovement>().startPosition;
        }
        GameOverDisplay.OnGameRestart();
    }
}
