using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicMushroomPowerup : BasePowerup
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        type = PowerupType.MagicMushroom;
    }

    public override void SpawnPowerup()
    {
        spawned = true;
        rigidBody.AddForce(Vector2.right*3,ForceMode2D.Impulse);
    }

    public override void ApplyPowerup(MonoBehaviour i)
    {
        // TODO: complete this
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && spawned)
        {
            // TODO: take effect
            
            DestroyPowerup();
        }else if (other.gameObject.layer == 10)
        {
            if (spawned)
            {
                goRight = !goRight;
                rigidBody.AddForce(Vector2.right*3*(goRight?1:-1),ForceMode2D.Impulse);
            }
        }
    }
}
