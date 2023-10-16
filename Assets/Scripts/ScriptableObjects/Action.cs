using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : ScriptableObject
{
    public abstract void Act(StateController controller);
}

public enum ActionType
{
    Attack = 0,
    Default = -1
}

[System.Serializable]
public struct EventAction
{
    public Action action;
    public ActionType type;
}