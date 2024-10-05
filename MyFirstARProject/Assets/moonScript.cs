using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Animator mAnimatorMoon;
    private Animator mAnimatorRocket;
    private Transform moonTransform;
    private Transform rocketTransform;

    void Start()
    {
        mAnimatorMoon = GameObject.Find("moon").GetComponent<Animator>();
        mAnimatorRocket = GameObject.Find("rocket_done").GetComponent<Animator>();

        moonTransform = GameObject.Find("moon").GetComponent<Transform>();
        rocketTransform = GameObject.Find("rocket_done").GetComponent<Transform>();
    }

    void Update()
    {
        Debug.Log(Vector3.Distance(moonTransform.position, rocketTransform.position));

        if (Vector3.Distance(moonTransform.position, rocketTransform.position) <= 0.325)   //attack
        {
            mAnimatorMoon.SetTrigger("Trigger_scale");
            mAnimatorRocket.SetTrigger("Trigger_fly");
        }
        else{ //idle
             
            mAnimatorMoon.SetTrigger("Trigger_rotate");
            mAnimatorRocket.SetTrigger("Trigger_idle");
        }
    }
}
