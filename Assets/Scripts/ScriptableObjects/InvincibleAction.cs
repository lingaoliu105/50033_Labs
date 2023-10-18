using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableSM/Actions/SetupInvincibility")]
public class InvincibleAction : Action
{
    public AudioClip invincibilityStart;
    public RuntimeAnimatorController animatorController;

    public override void Act(StateController controller)
    {
        MarioStateController m = (MarioStateController)controller;
        m.gameObject.GetComponent<AudioSource>().PlayOneShot(invincibilityStart);
        controller.gameObject.GetComponent<Animator>().runtimeAnimatorController = animatorController;
        m.SetRendererToFlicker();
    }
}