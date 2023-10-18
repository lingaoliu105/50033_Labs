using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MarioStateController : StateController
{
    public PowerupType currentPowerupType = PowerupType.Default;
    public MarioState shouldBeNextState = MarioState.Default;
    
    public void Fire()
    {
        this.currentState.DoEventTriggeredActions(this, ActionType.Attack);
    }
    public override void Start()
    {
        base.Start();
        GameRestart(); // clear powerup in the beginning, go to start state
    }

    public new void Update()
    {
        base.Update();
        if (currentState.name == "DeadMario")
        {
            StartCoroutine(GameOverCoroutine());
        }
    }

    IEnumerator GameOverCoroutine()
    {
        yield return new WaitForSeconds(2);
        gameOver.Invoke();
    }

    // this should be added to the GameRestart EventListener as callback
    public void GameRestart()
    { 
        // clear powerup
        currentPowerupType = PowerupType.Default;
        // set the start state
        TransitionToState(startState);
    }

    public void SetPowerup(PowerupType i)
    {
        currentPowerupType = i;
    }
    
    
    private SpriteRenderer spriteRenderer;
    public GameConstants gameConstants;
    public UnityEvent gameOver;

    // other methods
    public void SetRendererToFlicker()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(BlinkSpriteRenderer());
    }
    private IEnumerator BlinkSpriteRenderer()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        while (string.Equals(currentState.name, "InvincibleSmallMario", StringComparison.OrdinalIgnoreCase))
        {
            // Toggle the visibility of the sprite renderer
            spriteRenderer.enabled = !spriteRenderer.enabled;

            // Wait for the specified blink interval
            yield return new WaitForSeconds(gameConstants.flickerInterval);
        }

        spriteRenderer.enabled = true;
    }
}


public enum MarioState
{
    Default = -1,
    SmallMario = 0,
    SuperMario = 1,
    FireMario = 2,
    InvincibleSmallMario = 3,
    DeadMario = 99
}