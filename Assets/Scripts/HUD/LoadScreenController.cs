using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadScreenController : MonoBehaviour
{
    public GameStatistics Statistics;
    private TextMeshProUGUI highestScoreText;
    private Canvas LoadingScreen;
    public CanvasGroup c;
    // Start is called before the first frame update
    private void Awake()
    {
        LoadingScreen = GetComponent<Canvas>();
    }

    void Start()
    {
        foreach (var textMeshPro in GetComponentsInChildren<TextMeshProUGUI>())
        {
            if (textMeshPro.gameObject.name == "HighScore")
            {
                highestScoreText = textMeshPro;
                break;
            }
        }
        UpdateScore();
    }

    public void ShowLoadingScreen()
    {
        LoadingScreen.gameObject.SetActive(true);
        UpdateScore();
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        for (float alpha = 2f; alpha >= -0.05f; alpha -= 0.05f)
        {
            c.alpha = alpha;
            yield return new WaitForSecondsRealtime(0.005f);
        }
        // once done, go to next scene
        LoadingScreen.gameObject.SetActive(false);
    }
    
    public void UpdateScore()
    {
        if (highestScoreText == null)
        {
            foreach (var textMeshPro in GetComponentsInChildren<TextMeshProUGUI>())
            {
                if (textMeshPro.gameObject.name == "HighScore")
                {
                    highestScoreText = textMeshPro;
                    break;
                }
            }
        }
        highestScoreText.text = "TOP - " + Statistics.highestScore.ToString("D8");
    }
}
