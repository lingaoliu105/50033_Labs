using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesManager : MonoBehaviour
{
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