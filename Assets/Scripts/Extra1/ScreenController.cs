using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;


public class ScreenController : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI Text;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnGameOver(float score)
    {

        Text.text = "Game Over";
        ScoreText.text = "Score: " + Mathf.Round(score);
        gameObject.SetActive(true);
    }
    public void OnWin(float score)
    {
        Text.text = "You Win!";
        ScoreText.text = "Score: " + Mathf.Round(score);
        gameObject.SetActive(true);
    }

    public void OnGameRestart()
    {
        gameObject.SetActive(false);
    }
}
