using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
