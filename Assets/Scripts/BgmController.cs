using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmController : MonoBehaviour
{
    public AudioClip[] audios;
    public Transform player;
    private bool changed = false;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<AudioSource>().clip = audios[0];
        this.GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<AudioSource>().isPlaying)
        {
            if (player.transform.position.x > 15 && changed == false)
            {
                this.GetComponent<AudioSource>().clip = audios[1];
                this.GetComponent<AudioSource>().Play();
                changed = true;
            }
        }
    }
}
