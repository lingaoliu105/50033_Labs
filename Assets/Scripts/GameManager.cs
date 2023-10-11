using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : Singleton<GameManager>
{

    public UnityEvent gameStart;
    public UnityEvent gameReset;
    public UnityEvent<int> scoreChange;
    public UnityEvent<int> gameOver;
    public UnityEvent gamePause;
    public UnityEvent gameResume;
    public UnityEvent highestScoreUpdate;
    public UnityEvent gameBackToMain;
    public UnityEvent playMusic;
    
    public GameStatistics statistics;
    

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0.0f;
        SceneManager.activeSceneChanged += SceneSetup;
        statistics.score = 0;
    }

    private void SceneSetup(Scene arg0, Scene arg1)
    {
        gameStart.Invoke();
        SetScore(statistics.score);
    }

    public void PlayMusic()
    {
        playMusic.Invoke();
    }
    
    public void GameOver()
    {
        Time.timeScale = 0.0f;
        gameOver.Invoke(statistics.score);
    }

    public void RestartButtonCallback()
    {
        ResetGame();
    }

    public void BackToMainCasllback()
    {
        ResetGame();
        gameBackToMain.Invoke();
    }

    void SetScore(int score)
    {
        statistics.score = score;
        if (statistics.score > statistics.highestScore)
        {
            statistics.highestScore = statistics.score;
            highestScoreUpdate.Invoke();
        }
        scoreChange.Invoke(score);
    }

    public void IncreaseScore(int increment)
    {
        SetScore(statistics.score+increment);
    }
    public void ResetGame()
    {
        SetScore(0);        
        gameReset.Invoke();
        Time.timeScale = 1.0f;
    }

    public void StartGame()
    {
        gameStart.Invoke();
        Time.timeScale = 1.0f;
    }

    public void PauseGame()
    {
        Time.timeScale = 0.0f;    
        gamePause.Invoke();
    }

    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
        gameResume.Invoke();
    }

    public void ResetHighestScore()
    {
        statistics.highestScore = 0;
        highestScoreUpdate.Invoke();
    }
}
