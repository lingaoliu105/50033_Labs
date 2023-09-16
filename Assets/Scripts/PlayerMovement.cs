using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10;
    private Rigidbody2D marioBody;
    public float maxSpeed = 20;

    public float upSpeed = 30;
    private bool onGroundState = true;

    private SpriteRenderer marioSprite;
    private bool faceRightState = true;

    public GameManager GameManager;

    public Vector3 DefaultPostion;
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground")) onGroundState = true;
        if (col.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Collided with goomba!");
            GameManager.GameOver();
            Time.timeScale = 0.0f;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        // Set to be 30 FPS
        Application.targetFrameRate =  30;
        marioBody = GetComponent<Rigidbody2D>();
        marioSprite = GetComponent<SpriteRenderer>();
    }

    // FixedUpdate is called 50 times a second
    void  FixedUpdate()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        if (Mathf.Abs(moveHorizontal) > 0)
        {
            Vector2 movement = new Vector2(moveHorizontal, 0);
            if (marioBody.velocity.magnitude < maxSpeed)
            {
                
                marioBody.AddForce(movement * speed);
            }
            
        }

        if (Input.GetKeyUp("a") || Input.GetKeyUp("d"))
        {
            marioBody.velocity = Vector2.zero;
        }
        
        if (Input.GetKeyDown("space") && onGroundState){
            marioBody.AddForce(Vector2.up * upSpeed, ForceMode2D.Impulse);
            onGroundState = false;
        }
    }
    
    
    void Update(){
        // toggle state
        if (Input.GetKeyDown("a") && faceRightState){
            faceRightState = false;
            marioSprite.flipX = true;
        }

        if (Input.GetKeyDown("d") && !faceRightState){
            faceRightState = true;
            marioSprite.flipX = false;
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Collided with goomba!");
        }
    }

    public void Reset()
    {
        marioBody.transform.position = DefaultPostion;
        // reset sprite direction
        faceRightState = true;
        marioSprite.flipX = false;
    }
}
