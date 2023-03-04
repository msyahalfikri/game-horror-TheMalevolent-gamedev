using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightAnimationController : MonoBehaviour
{
    public PlayerMovement movement;
    public PlayerMovement.movementState state;
    public Animator flashlightAnimator;
    private void Update()
    {
        flashlightAnimator.speed = movement.flashlightAnimationSpeed;
        SetFlashlightAnimation();
    }
    private void SetFlashlightAnimation()
    {
        state = movement.state;
        if (state == PlayerMovement.movementState.sprinting)
        {
            AnimationStateSet(true, false, false);
        }
        else if (state == PlayerMovement.movementState.walking || state == PlayerMovement.movementState.crouchingWalking)
        {
            AnimationStateSet(false, true, false);
        }
        else
        {
            AnimationStateSet(false, false, true);
        }
    }
    private void AnimationStateSet(bool sprintState, bool walkState, bool idleState)
    {
        flashlightAnimator.SetBool("isSprinting", sprintState);
        flashlightAnimator.SetBool("IsWalking", walkState);
        flashlightAnimator.SetBool("IsIdle", idleState);
    }

}
