using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class JumpOverGoomba : MonoBehaviour
{
    public Transform enemyLocation;
    public TextMeshProUGUI scoreText;
    private bool _onGroundState;

    [System.NonSerialized]
    public int Score = 0; // we don't want this to show up in the inspector

    private bool _countScoreState = false;
    public Vector3 boxSize;
    public float maxDistance;
    public LayerMask layerMask;
    
    void FixedUpdate()
    {
        // mario jumps
        if (Input.GetKeyDown("space") && OnGroundCheck())
        {
            _onGroundState = false;
            _countScoreState = true;
        }

        // when jumping, and Goomba is near Mario and we haven't registered our score
        if (!_onGroundState && _countScoreState)
        {
            if (Mathf.Abs(transform.position.x - enemyLocation.position.x) < 0.5f)
            {
                _countScoreState = false;
                Score++;
                scoreText.text = "Score: " + Score;
                Debug.Log(Score);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground")) _onGroundState = true;
    }


    private bool OnGroundCheck()
    {
        return Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, maxDistance, layerMask);
    }
    
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(transform.position - transform.up * maxDistance, boxSize);
    }
}