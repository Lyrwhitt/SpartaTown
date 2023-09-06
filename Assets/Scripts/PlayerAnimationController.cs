using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator _animator;

    public void SetAnimator(Animator animator)
    {
        _animator = animator;
    }

    public void SetMoveState(bool isMove)
    {
        if(isMove)
        {
            _animator.SetBool("IsMove", true);
        }
        else
        {
            _animator.SetBool("IsMove", false);
        }
    }
}
