using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmController : MonoBehaviour
{
    public AudioSource BgmAudio;

    private bool gameStarted = false; 
    // Start is called before the first frame update
    void Start()
    {
        BgmAudio = GetComponent<AudioSource>();
    }
    
    public void PlayMusic()
    {
        gameStarted = true; 
        GetComponent<AudioSource>().Play();
    }

    public void PauseMusic()
    {
        GetComponent<AudioSource>().Pause();
    }

    public void StopMusic()
    {
        GetComponent<AudioSource>().Stop();
    }
}
