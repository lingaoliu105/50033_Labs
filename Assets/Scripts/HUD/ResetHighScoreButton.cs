using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ResetHighScoreButton : MonoBehaviour,IInteractiveButton
{
    public UnityEvent resetHighScoreEvent;
    public void ButtonClick()
    {
        resetHighScoreEvent.Invoke();
    }
}
