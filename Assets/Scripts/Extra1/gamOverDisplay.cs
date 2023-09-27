using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
public class gamOverDisplay : MonoBehaviour
{
    public TextMeshProUGUI GOScoreText;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
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
