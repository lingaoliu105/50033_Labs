using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Variable<T> : ScriptableObject
{
#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
#endif

    protected T _value;
    public T Value
    {
        get
        {
            return _value;
        }
        set
        {
            SetValue(value);

        }
    }

    public abstract void SetValue(T value);

}

[CreateAssetMenu(fileName = "IntVariable", menuName = "ScriptableObjects/IntVariable", order = 2)]
public class IntVariable : Variable<int>
{

    public int previousHighestValue;
    public override void SetValue(int value)
    {
        if (value > previousHighestValue) previousHighestValue = value;

        _value = value;
    }

    // overload
    public void SetValue(IntVariable value)
    {
        SetValue(value.Value);
    }

    public void ApplyChange(int amount)
    {
        this.Value += amount;
    }

    public void ApplyChange(IntVariable amount)
    {
        ApplyChange(amount.Value);
    }

    public void ResetHighestValue()
    {
        previousHighestValue = 0;
    }

}

[CreateAssetMenu(fileName = "BoolVariable", menuName = "ScriptableObjects/BoolVariable", order = 3)]
public class BoolVariable : Variable<bool>
{
    public override void SetValue(bool value)
    {
        _value = value;
    }
}