using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{

    public int direction;

    public float horizontalSpeed;

    public float mapLeftBoundary = -20;
    public float mapRightBoundary = 20;
    private Vector3 _spawnPosition;

    private Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        
        _spawnPosition = body.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (body.position.x < mapLeftBoundary || body.position.x > mapRightBoundary)
        {
            body.position = _spawnPosition;
        }
        
        body.MovePosition(body.position+Vector2.left * (direction * horizontalSpeed));
    }
    
    public void ResetObject()
    {
        transform.position = _spawnPosition;
    }
}
