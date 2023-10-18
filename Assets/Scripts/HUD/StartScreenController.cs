using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartScreenController : MonoBehaviour
{
    private TextMeshProUGUI highestScoreText;
    public GameStatistics stats;

    private void Start()
    {
        stats.score = 0;
        foreach (var textMeshPro in GetComponentsInChildren<TextMeshProUGUI>())
        {
            if (textMeshPro.gameObject.name == "HighScore")
            {
                highestScoreText = textMeshPro;
                break;
            }
        }
        highestScoreText.text=  highestScoreText.text = "TOP - " + stats.highestScore.ToString("D8");
    }

    public void UpdateHighScore(int newScore)
    {
        highestScoreText.text = "TOP - " + newScore.ToString("D8");
    }
}
