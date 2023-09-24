using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class QuestionBoxControl : MonoBehaviour
{
    private Rigidbody2D boxBody;

    private float defaultPositionY;

    private Animator boxAnim;

    private bool animTriggerIsSet;

    public bool willSpawnCoin;

    public CoinControl coin;

    // Start is called before the first frame update
    void Start()
    {
        var bodies = GetComponentsInChildren<Rigidbody2D>();
        foreach (var body in bodies)
        {
            if (body.bodyType == RigidbodyType2D.Dynamic)
                //find the dynamic one, not the static anchor on the root
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
        if (willSpawnCoin)
        {
            if (boxBody.transform.position.y > defaultPositionY && Math.Abs(boxBody.transform.position.y - defaultPositionY) > 0.01 && !animTriggerIsSet)
            {
                boxAnim.SetTrigger("hitFromBottom");
                animTriggerIsSet = true;
                SpawnCoin();
            }
            if (Math.Abs(boxBody.transform.position.y - defaultPositionY) < 0.01 && animTriggerIsSet)
            {
                animTriggerIsSet = false;
            }
            
        }
    }
    void SpawnCoin()
    {
        if (willSpawnCoin)
        {
            // coin.SetParent(gameObject);
            coin.Spawn();
        }
    }

    // Methods below are to be invoked as anim event callback
    void Disable()
    {
        boxBody.bodyType = RigidbodyType2D.Static;
    }

}
