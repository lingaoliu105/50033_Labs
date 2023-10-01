using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Rigidbody2D player;
    public float sensitive = 15f; //左右平移幅度

    public gameManager gm;

    public Vector3 defaultPosition; //记录原点

    private void Update()
    {
        PlayerController();
        checkEdge();
    }

    private void checkEdge()
    {
        if (transform.position.x < -6f)
        {
            transform.position = new Vector2(6f, transform.position.y);
        }
        if (transform.position.x > 6f)
        {
            transform.position = new Vector2(-6f, transform.position.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (player.velocity.y <= 0)
        {
            if (col.CompareTag("board"))
            {
                player.velocity = new Vector2(0f, 10f);
            }
        }

        if (col.CompareTag("win"))
        {
            gm.GameOver();
        }
    }

    private void PlayerController()
    {
        float horizontalAxis = 0;
        horizontalAxis = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown("a") || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }

        if (Input.GetKeyDown("d") || Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }

        player.velocity = new Vector2(horizontalAxis * sensitive, player.velocity.y);
    }

    public void Reset()
    {
        player.transform.position = defaultPosition;
    }
}
