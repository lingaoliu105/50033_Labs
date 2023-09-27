using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerFollow : MonoBehaviour
{
    public Transform Player;
    private Vector3 Velocity;
    public Rigidbody2D playerRigidbody2D;
    public gameManager gm;
    public Vector3 defaultPosition;
    private void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }
    private void FixedUpdate()
    {
        if (Player.transform.position.y >= transform.position.y)
        {
            Vector3 target = new Vector3(transform.position.x, Player.transform.position.y, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, target, ref Velocity, 0.2f * Time.deltaTime);
        }
        if (Player.transform.position.y < transform.position.y - 8f)
        {
            gm.GameOver();
        }
    }
    public void Reset()
    {
        transform.position = defaultPosition;
    }
}
