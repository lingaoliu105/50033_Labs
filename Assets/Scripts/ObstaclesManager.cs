using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesManager : MonoBehaviour
{
    private void Awake()
    {
        GameManager.instance.gameReset.AddListener(ResetObject);
    }

    public void ResetObject()
    {
        foreach (Transform childTrans in transform)
        {
            if (childTrans.GetComponent<QuestionBoxControl>())
            {
                childTrans.GetComponent<QuestionBoxControl>().ResetObject();
            }
        }
    }
}
