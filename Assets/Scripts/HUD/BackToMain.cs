using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToMain : MonoBehaviour,IInteractiveButton
{
    public void ButtonClick()
    {
        GameManager.instance.BackToMainCasllback();
    }
}
