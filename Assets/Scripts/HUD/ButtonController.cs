
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonController : MonoBehaviour, IInteractiveButton
{
    
    public UnityEvent gameRestart;

    public void ButtonClick()
    {
        Time.timeScale = 1.0f;
        gameRestart.Invoke();
    }

}