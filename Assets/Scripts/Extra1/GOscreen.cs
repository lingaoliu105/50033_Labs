using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;


public class GOscreen : MonoBehaviour
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

    public void OnGameOver(float score)
    {
        GOScoreText.text = "Score: " + Mathf.Round(score);
        gameObject.SetActive(true);
    }

    public void OnGameRestart()
    {
        gameObject.SetActive(false);
    }
}
