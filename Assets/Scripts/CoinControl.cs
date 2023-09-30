using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinControl : MonoBehaviour
{
    private Rigidbody2D coinBody;

    public GameObject parentBox;
    public float spawnForce;
    private AudioSource coinAudio;
    private Vector2 defaultPosition;

    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        defaultPosition = transform.position;
        coinAudio = GetComponent<AudioSource>();
        
        coinBody = GetComponent<Rigidbody2D>();
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject == parentBox)
        {
            coinAudio.PlayOneShot(coinAudio.clip);
            gameManager.IncreaseScore(1);
            Hide();
        }
    }

    private void Hide()
    {
        // will affect audio play:
        // gameObject.SetActive(false);

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    }
    

    public void Spawn()
    {
        gameObject.SetActive(true);

        coinBody.AddForce(Vector2.up*spawnForce,ForceMode2D.Impulse);
    }

    public void ResetObject()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Collider2D>().enabled = true;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        transform.position = defaultPosition;
        gameObject.SetActive(false);
    }
}
