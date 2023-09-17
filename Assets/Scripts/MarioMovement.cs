using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioMovement : MonoBehaviour
{
    public int Hp = 1;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        if (horizontal != 0)
        {
            //向右*速度*正负（右左）
            transform.Translate(transform.right * 1f * Time.deltaTime * horizontal);
            //转向
            if (horizontal > 0)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            if (horizontal < 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            anim.SetBool("mario_run", true);
        }
        else
        {
            anim.SetBool("mario_run", false);
        }
    }
}
