using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartScreenController : MonoBehaviour
{
    private TextMeshProUGUI highestScoreText;
    // Start is called before the first frame update
    protected void Awake()
    {
        GameManager.instance.highestScoreUpdate.AddListener(UpdateScore);
    }
    void Start()
    {
        UpdateScore();
    }
    

    void UpdateScore()
    {
        foreach (var textMeshPro in GetComponentsInChildren<TextMeshProUGUI>())
        {
            if (textMeshPro.gameObject.name == "HighScore")
            {
                highestScoreText = textMeshPro;
                break;
            }
        }
        highestScoreText.text = "TOP - " + GameManager.instance.statistics.highestScore.ToString("D8");
    }
}
