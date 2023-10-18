using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BackToMainButton : MonoBehaviour,IInteractiveButton
{
    public UnityEvent backToMainEvent;
    public UnityEvent gameResetEvent;
    public void ButtonClick()
    {
        gameResetEvent.Invoke();
        Time.timeScale = 0.0f;
        backToMainEvent.Invoke();
    }
}
