
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour, IInteractiveButton
{
    public void ButtonClick()
    {
        GameManager.instance.RestartButtonCallback();
    }
}
