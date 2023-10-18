using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BackToMainButton : MonoBehaviour,IInteractiveButton
{
    public UnityEvent backToMainEvent;
    public void ButtonClick()
    {
        backToMainEvent.Invoke();
    }
}
