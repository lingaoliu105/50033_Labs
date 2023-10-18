using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireflowerPowerup : BasePowerup
{
    public AudioSource FireflowerPop;
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        type = PowerupType.FireFlower;
        Hide();
    }

    public override void Spawn()
    {
        FireflowerPop.Play();
        Show();
        spawned = true;
        rigidBody.AddForce(Vector2.up * spawnForce, ForceMode2D.Impulse);
    }
    
    public override void ApplyPowerup(MonoBehaviour i)
    {
        MarioStateController mario;
        bool result = i.TryGetComponent<MarioStateController>(out mario);
        if (result)
        {
            mario.SetPowerup(this.powerupType);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.CompareTag("Player") && spawned)
        {
            // TODO: take effect
            Hide();
            audio.PlayOneShot(audio.clip);
            ApplyPowerup(other.gameObject.GetComponent<MonoBehaviour>());
        }
    }
}
