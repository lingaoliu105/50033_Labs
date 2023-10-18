using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ResetHighScoreButton : MonoBehaviour,IInteractiveButton
{
    public UnityEvent<int> resetHighScoreEvent;
    public GameStatistics stats;
    public void ButtonClick()
    {
        stats.highestScore = 0;
        resetHighScoreEvent.Invoke(0);
    }
}
