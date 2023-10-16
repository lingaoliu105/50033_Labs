using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableSM/Decisions/Countdown")]
public class CountdownDecision : Decision
{
    public float buffDuration;
    public override bool Decide(StateController controller)
    {
        return controller.CheckIfCountDownElapsed(buffDuration);
    }
}