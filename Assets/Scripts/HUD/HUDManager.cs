using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    private Canvas gameScreen;
    private Canvas gameOverScreen;
    private Canvas gameStartScreen;
    private Canvas pauseScreen;

    void Awake()
    {
        GameManager gm = GameManager.instance;
        gm.gameStart.AddListener(GameStart);
        gm.gameReset.AddListener(ResetObject);
        gm.gameOver.AddListener(GameOver);
        gm.gamePause.AddListener(ShowPauseScreen);
        gm.gameResume.AddListener(ClosePauseScreen);
    }

    private void ClosePauseScreen()
    {
        pauseScreen.gameObject.SetActive(false);
    }

    private void ShowPauseScreen()
    {
        pauseScreen.gameObject.SetActive(true);
    }

    private void GameOver(int arg0)
    {
        gameOverScreen.gameObject.SetActive(true);
        gameScreen.gameObject.SetActive(false);
    }

    private void ResetObject()
    {
        gameOverScreen.gameObject.SetActive(false);
        gameScreen.gameObject.SetActive(true);
        pauseScreen.gameObject.SetActive(false);
        gameStartScreen.gameObject.SetActive(false);
    }

    private void GameStart()
    {
        gameStartScreen.gameObject.SetActive(false);
        gameScreen.gameObject.SetActive(true);
    }

    void Start()
    {
        foreach (Transform childTransform in transform)
        {
            switch (childTransform.name)
            {
                case "GameOverScreen":
                    gameOverScreen = childTransform.GetComponent<Canvas>();
                    gameOverScreen.gameObject.SetActive(false);
                    break;
                case "GameStartScreen":
                    gameStartScreen = childTransform.GetComponent<Canvas>();
                    gameStartScreen.gameObject.SetActive(true);
                    break;
                case "PauseScreen":
                    pauseScreen = childTransform.GetComponent<Canvas>();
                    pauseScreen.gameObject.SetActive(false);
                    break;
                case "GameScreen":
                    gameScreen = childTransform.GetComponent<Canvas>();
                    gameScreen.gameObject.SetActive(false);
                    break;
            }
        }
    }


}
