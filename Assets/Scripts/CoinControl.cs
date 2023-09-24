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

    // Start is called before the first frame update
    void Start()
    {
        coinAudio = GetComponent<AudioSource>();
        
        coinBody = GetComponent<Rigidbody2D>();
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject == parentBox)
        {
            coinAudio.PlayOneShot(coinAudio.clip);
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
}
