using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadScreenController : MonoBehaviour
{
    private TextMeshProUGUI highestScoreText;

    public CanvasGroup c;
    // Start is called before the first frame update
    protected void Awake()
    {
        GameManager.instance.highestScoreUpdate.AddListener(UpdateScore);
    }
    void Start()
    {
        UpdateScore();
    }

    public void ShowLoadingScreen()
    {
        UpdateScore();
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        for (float alpha = 2f; alpha >= -0.05f; alpha -= 0.05f)
        {
            c.alpha = alpha;
            yield return new WaitForSecondsRealtime(0.1f);
        }
        // once done, go to next scene
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
