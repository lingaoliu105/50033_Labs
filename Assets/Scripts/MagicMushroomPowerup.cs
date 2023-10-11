using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicMushroomPowerup : BasePowerup
{
    public AudioSource mashroomPop;
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        type = PowerupType.MagicMushroom;
        Hide();
    }

    public override void Spawn()
    {
        mashroomPop.Play();
        Show();
        spawned = true;
        rigidBody.AddForce(Vector2.up * spawnForce, ForceMode2D.Impulse);
    }

    public void Update()
    {
        if (spawned == true && rigidBody.bodyType==RigidbodyType2D.Dynamic)
        {
            rigidBody.MovePosition(rigidBody.position + Vector2.right * ((goRight?1:-1) * (3 * Time.fixedDeltaTime)));
        }
    }

    public override void ApplyPowerup(MonoBehaviour i)
    {
        // TODO: complete this
        Debug.Log("Magic Powerup");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.CompareTag("Player") && spawned)
        {
            // TODO: take effect
            Hide();
            audio.PlayOneShot(audio.clip);
            ApplyPowerup(other.gameObject.GetComponent<MonoBehaviour>());
        }else if (other.gameObject.layer == 3)
        {
            Debug.Log("Collide");
            if (spawned)
            {
                goRight = !goRight;
                Debug.Log(goRight);
            }
        }
    }
}
