using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmControllerTest : MonoBehaviour
{
    public AudioClip[] audios;
    public Transform player;
    private bool changed = false;

    private AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = audios[0];
        _audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (_audioSource.isPlaying)
        {
            if (player.transform.position.x > 15 && changed == false)
            {
                _audioSource.clip = audios[1];
                _audioSource.Play();
                changed = true;
            }
        }
    }

    void OnGameOver()
    {
        if (_audioSource.isPlaying)
        {
            
        }
    }
}
