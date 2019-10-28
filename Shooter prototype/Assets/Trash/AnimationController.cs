using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator _myAnimator;

    void Start()
    {
        _myAnimator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _myAnimator.SetBool("Jump", true);
        }
    }

    public void StopJumping()
    {
        _myAnimator.SetBool("Jump", false);
    }


}
