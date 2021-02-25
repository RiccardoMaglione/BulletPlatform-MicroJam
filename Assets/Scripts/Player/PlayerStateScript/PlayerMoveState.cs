﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.gameObject.transform.position.x <= 6 && animator.gameObject.transform.position.x >= -6)
        {
            animator.gameObject.transform.Translate(Vector3.right * animator.GetComponent<PlayerController>().Speed * Time.deltaTime * animator.GetComponent<PlayerController>().h);
        }

        if (animator.GetComponent<PlayerController>().h == 0)
            animator.SetBool("IsMove", false);

        if (Input.GetKeyDown(KeyCode.Space))
            animator.SetBool("IsJump", false);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}