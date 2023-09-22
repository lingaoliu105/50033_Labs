using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private float originalX;
    private float maxOffset = 5.0f;
    private float enemyPatroltime = 2.0f;
    private int moveRight = -1;
    private Vector2 velocity;

    private Rigidbody2D enemyBody;

    private Vector3 startPosition;
    int collisionLayerMask = (1 << 3) | (1 << 7);


    void Start()
    {
        startPosition = transform.position;
        enemyBody = GetComponent<Rigidbody2D>();
        // get the starting position
        originalX = transform.position.x;
        ComputeVelocity();
        
    }
    void ComputeVelocity()
    {
        velocity = new Vector2((moveRight) * maxOffset / enemyPatroltime, 0);
    }
    void Movegoomba()
    {
        enemyBody.MovePosition(enemyBody.position + velocity * Time.fixedDeltaTime);
    }

    void Update()
    {
        if (Mathf.Abs(enemyBody.position.x - originalX) < maxOffset)
        {// move goomba
            Movegoomba();
        }
        else
        {
            // change direction
            moveRight *= -1;
            ComputeVelocity();
            Movegoomba();
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    { 
        if ((collisionLayerMask & (1 << collision.gameObject.layer))>0)
        {
            if (collision.transform.position.x < transform.position.x)
            {
                moveRight =1;
                
            }
            else
            {
                moveRight = -1;
            }
            ComputeVelocity();
            Movegoomba();
            
        }
    }

    public void ResetPosition()
    {
        transform.position = startPosition;
    }
}