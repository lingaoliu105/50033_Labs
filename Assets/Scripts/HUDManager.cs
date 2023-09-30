using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    private TextMeshProUGUI scoreText;

    void Start()
    {
        scoreText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void SetScoreText(int score)
    {
        scoreText.text = "Score: " + score;
    }
}
