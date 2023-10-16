using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent<T> : ScriptableObject
{
    private readonly List<GameEventListener<T>> eventListeners = new List<GameEventListener<T>>();

    public void Raise(T data)
    {
        for (int i = eventListeners.Count-1; i >=0 ; i--)
        {
            eventListeners[i].onEventRaised(data);
        }
    }

    public void RegisterListener(GameEventListener<T> listener)
    {
        if (!eventListeners.Contains(listener))
        {
            eventListeners.Add(listener);
        }
    }

    public void UnregisterListener(GameEventListener<T> listener)
    {
        if (eventListeners.Contains(listener))
            eventListeners.Remove(listener);
    }
}

[CreateAssetMenu(fileName = "IntGameEvent",menuName = "ScriptableObjects/IntGameEvent",order = 4)]
public class IntGameEvent : GameEvent<int>
{
    
}

[CreateAssetMenu(fileName = "PowerupGameEvent",menuName = "ScriptableObjects/PowerupGameEvent",order = 5)]
public class PowerupGameEvent : GameEvent<IPowerUp>
{
    
}


