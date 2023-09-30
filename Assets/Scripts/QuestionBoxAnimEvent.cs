using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionBoxAnimEvent : MonoBehaviour
{
    // to be invoked as anim event callback
    public void Disable()
    {
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    }
}
