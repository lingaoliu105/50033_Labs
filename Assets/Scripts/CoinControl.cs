using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoinControl : BasePowerup
{
    public GameStatistics stats;
    public UnityEvent<int> IncreaseScore;
    public UnityEvent<int> updateHighest;
    public GameObject parentBox;
    // Start is called before the first frame update
    private new void Start()
    {
        base.Start();
        type = PowerupType.Coin;
        Hide();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject == parentBox)
        {
            audio.PlayOneShot(audio.clip);
            stats.score++;
            if (stats.score > stats.highestScore)
            {
                stats.highestScore = stats.score;
                updateHighest.Invoke(stats.highestScore);
            }
            IncreaseScore.Invoke(stats.score);
            ApplyPowerup(null); //No specific object to receive this effect
            Hide();
        }
    }
    
    public override void Spawn()
    {
        Show();
        spawned = true;
        rigidBody.AddForce(Vector2.up * spawnForce, ForceMode2D.Impulse);
    }
    
    public override void ApplyPowerup(MonoBehaviour i)
    {
    }
}
