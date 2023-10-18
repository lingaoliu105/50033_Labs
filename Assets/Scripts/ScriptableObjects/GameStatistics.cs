using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameStatistics",menuName = "ScriptableObjects/GameStatistics",order = 2)]

public class GameStatistics : ScriptableObject
{
    public int score;
    public int highestScore;
    public int currentScene;
}
