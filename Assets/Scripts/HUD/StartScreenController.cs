using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartScreenController : MonoBehaviour
{
    public GameStatistics Statistics;
    private TextMeshProUGUI highestScoreText;
    // Start is called before the first frame update
    void Start()
    {
        UpdateScore();
    }
    

    public void UpdateScore()
    {
        foreach (var textMeshPro in GetComponentsInChildren<TextMeshProUGUI>())
        {
            if (textMeshPro.gameObject.name == "HighScore")
            {
                highestScoreText = textMeshPro;
                break;
            }
        }
        highestScoreText.text = "TOP - " + Statistics.highestScore.ToString("D8");
    }
}
