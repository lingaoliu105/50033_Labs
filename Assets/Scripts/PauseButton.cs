using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class PauseButton : MonoBehaviour,IInteractiveButton
{
    private bool isPaused = false;

    public Sprite pauseIcon;

    public Sprite playIcon;

    private Image image;
    void Start()
    {
        image = GetComponent<Image>();
    }

    public void ButtonClick()
    {
        if (isPaused)
        {
            // GameManager.instance.ResumeGame();
            image.sprite = pauseIcon;
        }
        else
        {
            // GameManager.instance.PauseGame();
            image.sprite = playIcon;
        }
        isPaused = !isPaused;
    }
}
