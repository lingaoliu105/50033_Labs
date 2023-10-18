using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableSM/Actions/SetupInvincibility")]
public class InvincibleAction : Action
{
    public AudioClip invincibilityStart;

    public override void Act(StateController controller)
    {
        try
        {
           MarioStateController m = (MarioStateController)controller;
            m.gameObject.GetComponent<AudioSource>().PlayOneShot(invincibilityStart);
            m.SetRendererToFlicker();
        }
        catch (InvalidCastException e)
        {
            BuffStateController m = (BuffStateController)controller;
            m.gameObject.GetComponent<AudioSource>().PlayOneShot(invincibilityStart);
            m.SetRendererToFlicker();
        }
    }
}