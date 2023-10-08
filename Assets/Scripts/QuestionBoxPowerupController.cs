using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionBoxPowerupController : MonoBehaviour,IPowerupController
{
    public Animator powerupAnimator;

    public BasePowerup powerup;
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Player") || powerup.hasSpawned) return;
        GetComponent<Animator>().SetTrigger("spawned");
        powerupAnimator.SetTrigger("spawned");
    }

    public void Disable()
    {
        _rigidbody2D.bodyType = RigidbodyType2D.Static;
        transform.localPosition = Vector3.zero;
    }
}
