using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableSM/Actions/ClearPowerup")]
public class ClearPowerupAction : Action
{
    public override void Act(StateController controller)
    {
        MarioStateController m = (MarioStateController)controller;
        m.currentPowerupType = PowerupType.Default;
    }
}
