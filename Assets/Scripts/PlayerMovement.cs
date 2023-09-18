using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 15;
    private Rigidbody2D _marioBody;
    public float maxSpeed = 45;

    public float upSpeed = 18;
    private bool _onGroundState = true;

    private SpriteRenderer _marioSprite;
    private bool _faceRightState = true;

    public GameManager gameManager;

    public Vector3 defaultPosition;

    public Animator marioAnimator;
    public AudioSource marioAudio;
    public AudioClip marioDeath;

    public float deathImpulse = 30;
    // state
    [System.NonSerialized]
    public bool alive = true;

    // Start is called before the first frame update
    void Start()
    {
        // Set to be 30 FPS
        Application.targetFrameRate = 30;
        _marioBody = GetComponent<Rigidbody2D>();
        _marioSprite = GetComponent<SpriteRenderer>();

        if (marioAnimator == null)
        {
            marioAnimator = GetComponent<Animator>();
        }
        marioAnimator.SetBool("onGround", _onGroundState);

        if (marioAudio == null)
        {
            marioAudio = GetComponent<AudioSource>();
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground") && !_onGroundState)
        {
            _onGroundState = true;
            marioAnimator.SetBool("onGround", _onGroundState);

        }
        if (col.gameObject.CompareTag("Enemy") && alive)
        {
            Debug.Log("Collided with goomba!");

            // play death animation
            marioAnimator.Play("mario_die");
            marioAudio.PlayOneShot(marioDeath);
            alive = false;
        }
    }
    void PlayJumpSound()
    {
        // play jump sound
        marioAudio.PlayOneShot(marioAudio.clip);
    }

    void PlayDeathImpulse()
    {
        _marioBody.AddForce(Vector2.up * deathImpulse, ForceMode2D.Impulse);
    }

    // FixedUpdate is called 50 times a second
    void FixedUpdate()
    {
        if (alive)
        {
            float moveHorizontal = Input.GetAxisRaw("Horizontal");
            if (Mathf.Abs(moveHorizontal) > 0)
            {
                Vector2 movement = new Vector2(moveHorizontal, 0);
                if (_marioBody.velocity.magnitude < maxSpeed)
                {

                    _marioBody.AddForce(movement * speed);
                }

            }

            if (Input.GetKeyUp("a") || Input.GetKeyUp("d"))
            {
                _marioBody.velocity.Set(0, _marioBody.velocity.y);
            }

            if (Input.GetKeyDown("space") && _onGroundState)
            {
                _marioBody.AddForce(Vector2.up * upSpeed, ForceMode2D.Impulse);
                _onGroundState = false;
                marioAnimator.SetBool("onGround", _onGroundState);
            }
        }
    }


    void Update()
    {
        // toggle state
        if (Input.GetKeyDown("a") && _faceRightState)
        {
            if (_marioBody.velocity.x > 0.1f)
            {
                marioAnimator.SetTrigger("onSkid");
            }
            _faceRightState = false;
            _marioSprite.flipX = true;
        }

        if (Input.GetKeyDown("d") && !_faceRightState)
        {
            if (_marioBody.velocity.x < -0.1f)
            {
                marioAnimator.SetTrigger("onSkid");
            }
            _faceRightState = true;
            _marioSprite.flipX = false;
        }
        marioAnimator.SetFloat("xSpeed", MathF.Abs(_marioBody.velocity.x));
    }

    // void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.gameObject.CompareTag("Enemy") && alive)
    //     {
    //         Debug.Log("Collided with goomba!");
    //         
    //         // play death animation
    //         marioAnimator.Play("mario-die");
    //         marioAudio.PlayOneShot(marioDeath);
    //         alive = false;
    //     }
    // }

    void GameOver()
    {
        gameManager.GameOver();
    }

    public void Reset()
    {
        _marioBody.transform.position = defaultPosition;
        // reset sprite direction
        _faceRightState = true;
        _marioSprite.flipX = false;
        marioAnimator.SetTrigger("gameRestart");
        alive = true;
    }
}
