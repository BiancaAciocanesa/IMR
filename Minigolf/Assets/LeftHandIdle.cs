using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHandIdle : MonoBehaviour
{
    private Animator mAnimatorHand;

    void Start()
    {
        mAnimatorHand = GameObject.FindGameObjectWithTag("LeftHand").GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            mAnimatorHand.SetTrigger("IdleTrigger");
        }

        else if (Input.GetKeyUp(KeyCode.Z))
        {
            mAnimatorHand.SetTrigger("GrabTrigger");
        }
    }
}
