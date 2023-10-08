using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartScreenController : MonoBehaviour
{
    private TextMeshProUGUI highestScoreText;
    // Start is called before the first frame update
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

        highestScoreText.text = "Highest Score: " + GameManager.instance.statistics.highestScore;
    }

}
