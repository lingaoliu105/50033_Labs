using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableSM/Actions/SetupBlinkingEffect")]

public class Blink : Action
{
    public override void Act(StateController controller)
    {
        controller.BlinkSprite();
    }
}
