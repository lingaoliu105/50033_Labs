using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AbstractScoreDisplayer : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    
    protected void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        
    }

    public void SetScoreText(int score)
    {
        if (!scoreText)
        {
            scoreText = GetComponentInChildren<TextMeshProUGUI>();
        }
        scoreText.text = "Score: " + score;
    }
}
