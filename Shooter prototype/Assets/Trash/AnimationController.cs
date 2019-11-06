using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator _myAnimator;
    //AnimationClip anim;

    void Start()
    {
        _myAnimator = this.GetComponent<Animator>();
        //_myAnimator.speed = 5;
        //anim.averageSpeed
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _myAnimator.SetBool("Run", true);
        }
        else
        {
            _myAnimator.SetBool("Run", false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            _myAnimator.SetBool("Strafe right", true);
        }
        else
        {
            _myAnimator.SetBool("Strafe right", false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            _myAnimator.SetBool("Strafe left", true);
        }
        else
        {
            _myAnimator.SetBool("Strafe left", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _myAnimator.SetBool("Jump", true);
        }       

        if (Input.GetKey(KeyCode.LeftControl))
        {
            _myAnimator.SetBool("Squat", true);
        }
        else
        {
            _myAnimator.SetBool("Squat", false);
        }
    }

    public void StopJumping()
    {
        _myAnimator.SetBool("Jump", false);
    }

    public void StopRuning()
    {
        _myAnimator.SetBool("Run", false);
    }




}
