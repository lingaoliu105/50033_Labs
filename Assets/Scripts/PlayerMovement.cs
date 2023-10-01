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
    public AudioClip coinSound;
    public Transform gameCamera;

    public float deathImpulse = 30;

    public float marioHeight;

    public float marioWidth;
    int collisionLayerMask = (1 << 3) | (1 << 6) | (1 << 7);

    public Transform deathHeight;

    private bool moving = false;
    private bool jumpState = false;

    public float multiImpulse = 1.2f;
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
        if ((collisionLayerMask & (1 << col.gameObject.layer)) > 0 && !_onGroundState)
        {
            _onGroundState = true;
            marioAnimator.SetBool("onGround", _onGroundState);

        }
        if (col.gameObject.CompareTag("Ground") && !_onGroundState)
        {
            _onGroundState = true;
            marioAnimator.SetBool("onGround", _onGroundState);

        }

        if (col.gameObject.CompareTag("Enemy") && alive)
        {
            if (col.contacts.Length > 0)
            {
                Vector2 otherPosition = col.gameObject.transform.position;
                if (IsUnderneath(otherPosition))
                {
                    marioAnimator.SetBool("onGround", true);
                    var enemy = col.gameObject;
                    Debug.Log("kill enemy here");
                    gameManager.IncreaseScore(1);
                    Jump(multiImpulse);
                }
                else
                {
                    // play death animation
                    marioAnimator.Play("mario_die");
                    marioAudio.PlayOneShot(marioDeath);
                    alive = false;

                }
            }
        }

        if (col.gameObject.CompareTag("Coin") && alive)
        {
            Destroy(col.gameObject);
            Debug.Log("Get 1 coin here");
            var jumpScript = GetComponent<JumpOverGoomba>();
            marioAudio.PlayOneShot(coinSound);
            jumpScript.UpdateScore(1);
        }

        if (col.gameObject.CompareTag("oneTimePlatform") && alive)
        {

            Destroy(col.gameObject);
            Debug.Log("Get 1 coin here");
            var jumpScript = GetComponent<JumpOverGoomba>();
            jumpScript.UpdateScore(1);
        }
    }

    bool IsUnderneath(Vector2 point)
    {
        var position = transform.position;
        // Debug.DrawLine(position,point,Color.red);
        float right = position.x + marioWidth / 2;
        float left = position.x - marioWidth / 2;
        float foot = position.y - marioHeight / 2;
        return point.x > left && point.x < right && point.y < foot;
    }

    //attached to jump anim event
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
        if (alive && moving)
        {
           
            Move(_faceRightState?1:-1);
        }
    }

    void Move(int value)
    {
        Vector2 movement = Vector2.right*value;
        if (MathF.Abs(_marioBody.velocity.x) < maxSpeed)
        {
            _marioBody.AddForce(movement*speed);
        }
    }

    public void MoveCheck(int value)
    {
        if (value == 0)
        {
            moving = false;
        }
        else
        {
            FlipMarioSprite(value);
            moving = true;
            Move(value);
        }
    }
    public void Jump(float multi = 30)
    {
        if (alive && _onGroundState)
        {
            _marioBody.AddForce(Vector2.up * (upSpeed * multi), ForceMode2D.Impulse);
            _onGroundState = false;
            jumpState = true;
            marioAnimator.SetBool("onGround", _onGroundState);
        }

    }

    public void JumpHold()
    {
        if (alive && jumpState)
        {
            _marioBody.AddForce(Vector2.up*upSpeed*30,ForceMode2D.Force);
            jumpState = false;
        }
    }


    void Update()
    {
        marioAnimator.SetFloat("xSpeed", MathF.Abs(_marioBody.velocity.x));
    }

    void FlipMarioSprite(int value)
    {
        if (value == -1 && _faceRightState)
        {
            _faceRightState = false;
            _marioSprite.flipX = true;
            if (_marioBody.velocity.x > 0.05f)
            {
                marioAnimator.SetTrigger("onSkid");
            }
        }else if (value == 1 && !_faceRightState)
        {
            _faceRightState = true;
            _marioSprite.flipX = false;
            if (_marioBody.velocity.x < -0.05f)
            {
                marioAnimator.SetTrigger("onSkid");
            }
        }
    }

    void GameOver()
    {
        gameManager.GameOver();
    }

    public void ResetObject()
    {
        _marioBody.transform.position = defaultPosition;
        // reset sprite direction
        _faceRightState = true;
        _marioSprite.flipX = false;
        marioAnimator.SetTrigger("gameRestart");
        gameCamera.position = new Vector3(0, 1.25f, -10);
        alive = true;
    }
}
