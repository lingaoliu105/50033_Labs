using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarPowerup : BasePowerup
{
    public AudioSource starPop;
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        type = PowerupType.StarMan;
        Hide();
    }

    public override void Spawn()
    {
        starPop.Play();
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
        BuffStateController mario;
        bool result = i.TryGetComponent<BuffStateController>(out mario);
        if (result)
        {
            mario.SetPowerup(this.powerupType);
        }
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
            Debug.Log("Star Collide");
            if (spawned)
            {
                goRight = !goRight;
                Debug.Log(goRight);
            }
        }
    }
}
