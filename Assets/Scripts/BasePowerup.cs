using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class BasePowerup : MonoBehaviour, IPowerUp
{
    public PowerupType type;
    public bool spawned = false;
    protected bool consumed = false;
    protected bool goRight = true;
    protected Rigidbody2D rigidBody;
    protected SpriteRenderer sprite;
    protected Collider2D collider;
    protected Vector3 defaultPosition;
    public AudioSource audio;
    public float spawnForce;
    public UnityEvent evt;
    protected virtual void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        collider = GetComponent<Collider2D>();
        defaultPosition = transform.position;
        audio = GetComponent<AudioSource>();
    }

    public void DestroyPowerup()
    {
        Destroy(gameObject);
    }

    protected void Hide()
    {
        // will affect audio play:
        sprite.enabled = false;
        collider.enabled = false;
        rigidBody.bodyType = RigidbodyType2D.Static;
    }
    protected void Show()
    {
        // will affect audio play:
        sprite.enabled = true;
        collider.enabled = true;
        rigidBody.bodyType = RigidbodyType2D.Dynamic;
    }
    
    public void ResetObject()
    {
        goRight = true;
        transform.position = defaultPosition;
        Hide();
        spawned = false;
    }
    public abstract void Spawn();

    public abstract void ApplyPowerup(MonoBehaviour i);

    public PowerupType powerupType => type;

    public bool hasSpawned => spawned;
}
