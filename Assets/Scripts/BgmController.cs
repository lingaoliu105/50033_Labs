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

    private void Awake()
    {
        GameManager gm = GameManager.instance;
        gm.playMusic.AddListener(PlayMusic);
        gm.gamePause.AddListener(PauseMusic);
        gm.gameResume.AddListener(PlayMusic);
        gm.gameReset.AddListener(PlayMusic);
        gm.gameOver.AddListener(StopMusic);
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public void StopMusic(int i)
    {
        GetComponent<AudioSource>().Stop();
    }
}
