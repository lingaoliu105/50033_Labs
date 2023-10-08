using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : Singleton<EnemiesManager>
{
    private void Awake()
    {
        GameManager.instance.gameReset.AddListener(ResetObject);
    }

    private void ResetObject()
    {
        foreach (Transform child in transform)
        {
            if (child.GetComponent<EnemyMovement>())
            {
                child.GetComponent<EnemyMovement>().ResetObject();
            }
        }
        
    }
}
