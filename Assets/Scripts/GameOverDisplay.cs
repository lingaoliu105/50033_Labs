using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameOverDisplay : MonoBehaviour
{
    
    public TextMeshProUGUI GOScoreText;
    // Start is called before the first frame update
    void Start()
    {
        // update actual score
        // GOScoreText = GetComponentInChildren<TextMeshProUGUI>();
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(GOScoreText);

    }

    private void FixedUpdate()
    {
    }

    public void OnGameOver(int score)
    {
        GOScoreText.text = "Score: " + score;
        gameObject.SetActive(true);
    }

    public void OnGameRestart()
    {
        gameObject.SetActive(false);
    }
}
