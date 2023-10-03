using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
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
