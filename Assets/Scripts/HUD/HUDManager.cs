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
    private CanvasGroup FadedGroup;
    private LoadScreenController _loadScreenController;

    void Awake()
    {
        GameManager gm = GameManager.instance;
        gm.gameStart.AddListener(GameStart);
        gm.gameReset.AddListener(ResetObject);
        gm.gameOver.AddListener(GameOver);
        gm.gamePause.AddListener(ShowPauseScreen);
        gm.gameResume.AddListener(ClosePauseScreen);
        gm.gameBackToMain.AddListener(ResetScenes);
    }

    private void ResetScenes()
    {
        gameOverScreen.gameObject.SetActive(false);

        gameStartScreen.gameObject.SetActive(true);

        pauseScreen.gameObject.SetActive(false);

        gameScreen.gameObject.SetActive(false);

        FadedGroup.gameObject.SetActive(false);

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

    private IEnumerator GameStartCorountine()
    {
        gameStartScreen.gameObject.SetActive(false);
        FadedGroup.gameObject.SetActive(true);
        _loadScreenController.ShowLoadingScreen();
        yield return new WaitForSeconds(1);
        gameScreen.gameObject.SetActive(true);
        GameManager.instance.PlayMusic();
    }
    
    private void GameStart()
    {
        StartCoroutine(GameStartCorountine());
        //Invoke("GameScreenShow", 3f);;
    }

    private void GameScreenShow()
    {
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
                    gameStartScreen.gameObject.SetActive(GameManager.instance.isFirstScene);
                    break;
                case "PauseScreen":
                    pauseScreen = childTransform.GetComponent<Canvas>();
                    pauseScreen.gameObject.SetActive(false);
                    break;
                case "GameScreen":
                    gameScreen = childTransform.GetComponent<Canvas>();
                    gameScreen.gameObject.SetActive(!GameManager.instance.isFirstScene);
                    break;
                case "FadedGroup":
                    FadedGroup = childTransform.GetComponent<CanvasGroup>();
                    _loadScreenController = FadedGroup.gameObject.GetComponentInChildren<LoadScreenController>();
                    FadedGroup.gameObject.SetActive(false);
                    break;
            }
        }
    }
    
}
