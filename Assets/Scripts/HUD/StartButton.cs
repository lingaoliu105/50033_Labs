using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour,IInteractiveButton
{
    public void ButtonClick()
    {
        GameManager.instance.StartGame();
    }
}
