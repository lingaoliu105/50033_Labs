using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableSM/Actions/ClearPowerup")]
public class ClearPowerupAction : Action
{
    public override void Act(StateController controller)
    {
        try
        {
            MarioStateController m = (MarioStateController)controller;
            m.currentPowerupType = PowerupType.Default;

        }
        catch (InvalidCastException e)
        {
            BuffStateController m = (BuffStateController)controller;
            m.currentPowerupType = PowerupType.Default;
        }
    }
}
