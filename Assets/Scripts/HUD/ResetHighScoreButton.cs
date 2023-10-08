using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetHighScoreButton : MonoBehaviour,IInteractiveButton
{

    public void ButtonClick()
    {
        GameManager.instance.statistics.highestScore = 0;
    }
}
