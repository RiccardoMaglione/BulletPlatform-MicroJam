using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : StateMachineBehaviour
{
    public float jumpForce;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetBool("IsGround") == true && animator.GetBool("IsJump") == false)                                                                                                //Se tocca terra e non ha ancora saltato
        {
            animator.GetComponent<Rigidbody>().AddForce(Vector2.up * jumpForce, ForceMode.Impulse);                                                                                     //Salta tramite un impulso
            animator.SetBool("IsGround", false);
            animator.SetBool("IsJump", true);
        }

        if (animator.GetComponent<Rigidbody>().velocity.y < -0.1f)                                                                                                                      //Se la velocità y è minore di -0.1 passa allo stato di caduta
        {
            animator.SetBool("IsFall", true);
        }

        if (animator.gameObject.transform.position.x <= 6 && animator.gameObject.transform.position.x >= -6)                                                                            //Blocca i movimenti entro i confini
            animator.gameObject.transform.Translate(Vector3.right * animator.GetComponent<PlayerController>().Speed * Time.deltaTime * animator.GetComponent<PlayerController>().h);    //Consente di far muovere il player nel salto
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
