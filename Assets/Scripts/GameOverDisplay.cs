using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverDisplay : MonoBehaviour
{

    public GameObject GameOverScreen;
    // Start is called before the first frame update
    void Start()
    {
        GameOverScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnGameOver()
    {
        GameOverScreen.SetActive(true);
    }

    public void OnGameRestart()
    {
        GameOverScreen.SetActive(false);
    }
}
