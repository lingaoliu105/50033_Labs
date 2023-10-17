using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class QuestionBoxControl : MonoBehaviour,IPowerupController
{
    private Rigidbody2D boxBody;

    private float defaultPositionY;

    private Animator boxAnim;

    private bool animTriggerIsSet;

    public bool willSpawn;

    private BasePowerup powerUp;

    // Start is called before the first frame update
    void Start()
    {
        powerUp = GetComponentInChildren<BasePowerup>();
        Debug.Log(powerUp);
        var bodies = GetComponentsInChildren<Rigidbody2D>();
        foreach (var body in bodies)
        {
            if (body.gameObject.name=="Box")
            {
                boxBody = body;
            }
        }
        boxAnim = GetComponentInChildren<Animator>();
        
        defaultPositionY = boxBody.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (willSpawn)
        {
            if (boxBody.transform.position.y > defaultPositionY && Math.Abs(boxBody.transform.position.y - defaultPositionY) > 0.01 && !animTriggerIsSet)
            {
                boxAnim.SetTrigger("hitFromBottom");
                animTriggerIsSet = true;
                SpawnPowerup();
            }
            if (Math.Abs(boxBody.transform.position.y - defaultPositionY) < 0.01 && animTriggerIsSet)
            {
                Disable();
            }
            
        }
    }
    void SpawnPowerup()
    {
        if (willSpawn)
        {
            // coin.SetParent(gameObject);
            powerUp.Spawn();
        }
    }

    public void ResetObject()
    {
        animTriggerIsSet = false;
        boxBody.bodyType = RigidbodyType2D.Dynamic;
        boxAnim.SetTrigger("reset");
        powerUp.ResetObject();
    }

    public void Disable()
    {
        boxBody.bodyType = RigidbodyType2D.Static;
    }
}
