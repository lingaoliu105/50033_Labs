using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "PluggableSM/Decisions/Buff")]
public class BuffDecision : Decision
{
    public BuffTransformMap[] map;

    public override bool Decide(StateController controller)
    {
        BuffStateController m = (BuffStateController)controller;

        MarioBuff toCompareState = EnumExtension.ParseEnum<MarioBuff>(m.currentState.name);

        // loop through state transform and see if it matches the current transformation we are looking for
        for (int i = 0; i < map.Length; i++)
        {
            if (toCompareState == map[i].fromState && m.currentPowerupType == map[i].powerupCollected)
            {
                return true;
            }
        }

        return false;

    }
}

[System.Serializable]
public struct BuffTransformMap
{
    public MarioBuff fromState;
    public PowerupType powerupCollected;
}