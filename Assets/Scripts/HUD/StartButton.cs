using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartButton : MonoBehaviour,IInteractiveButton
{
    public UnityEvent startGame;
    public void ButtonClick()
    {
        startGame.Invoke();
    }
}
