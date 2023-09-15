using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameOverDisplay : MonoBehaviour
{

    public GameObject GameOverScreen;

    private TextMeshProUGUI GOScoreText;
    // Start is called before the first frame update
    void Start()
    {
        // update actual score
        GOScoreText = GetComponentInChildren<TextMeshProUGUI>();
        GameOverScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnGameOver(int score)
    {
        GOScoreText.text = "Score: " + score;
        GameOverScreen.SetActive(true);
    }

    public void OnGameRestart()
    {
        GameOverScreen.SetActive(false);
    }
}
