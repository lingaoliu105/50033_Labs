using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Image = UnityEngine.UI.Image;

public class PauseButton : MonoBehaviour,IInteractiveButton
{
    private bool isPaused = false;

    public Sprite pauseIcon;

    public Sprite playIcon;

    private Image image;

    public UnityEvent pauseEvent;
    public UnityEvent resumeEvent;
    void Start()
    {
        image = GetComponent<Image>();
    }

    public void ButtonClick()
    {
        if (isPaused)
        {
            pauseEvent.Invoke();
            image.sprite = pauseIcon;
        }
        else
        {
            resumeEvent.Invoke();
            image.sprite = playIcon;
        }
        isPaused = !isPaused;
    }
}
