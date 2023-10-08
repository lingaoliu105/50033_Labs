using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePowerup : MonoBehaviour,IPowerUp
{
    public PowerupType type;
    public bool spawned = false;
    protected bool consumed = false;
    protected bool goRight = true;
    protected Rigidbody2D rigidBody;

    protected virtual void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    public void DestroyPowerup()
    {
        Destroy(gameObject);
    }

    public abstract void SpawnPowerup();

    public abstract void ApplyPowerup(MonoBehaviour i);
    public PowerupType powerupType { get; }
    public bool hasSpawned { get; }
}
