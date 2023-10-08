using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{

    public string nextSceneName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("...");
        if (other.tag == "Player")
        {
            SceneManager.LoadSceneAsync(nextSceneName, LoadSceneMode.Single);
            
        } 
    }
}
