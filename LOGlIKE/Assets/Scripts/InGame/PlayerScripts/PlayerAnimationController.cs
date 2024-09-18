using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void BoolRunningAnimation(bool isRunning)
    {
        animator.SetBool("Run", isRunning);
    }
    public void TriggerJumpAnimation()
    {
        animator.SetTrigger("doJumping");
    }

    public  void TriggerAttackAnimation()
    {
        animator.SetTrigger("isAttack");

    }


}
   
