using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Rigidbody2D player;
    public float sensitive = 15f; //左右平移幅度

    public gameManager gm;

    public Vector3 defaultPosition; //记录原点

    public float edge = 6f;
    public AudioSource audio;
    public AudioSource jumpAudio;

    private void Update()
    {
        PlayerController();
        checkEdge();
    }

    private void checkEdge()
    {
        if (transform.position.x < -edge)
        {
            transform.position = new Vector2(edge, transform.position.y);
        }
        if (transform.position.x > edge)
        {
            transform.position = new Vector2(-edge, transform.position.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (player.velocity.y <= 0)
        {
            if (col.CompareTag("board"))
            {
                jumpAudio.PlayOneShot(jumpAudio.clip);
                player.velocity = new Vector2(0f, 10f);
            }
        }

        if (col.CompareTag("win"))
        {
            col.gameObject.SetActive(false);
            audio.PlayOneShot(audio.clip);
            gm.Win();
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
