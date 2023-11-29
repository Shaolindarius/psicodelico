using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : StateMachineBehaviour
{

    Transform Player;
    Rigidbody2D rb;
    DoctorMove doctormove;

    
    


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Player = GameObject.Find("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        doctormove = animator.GetComponent<DoctorMove>();
        animator.GetComponent<DoctorMove>().isAttacking = false;
    }
    

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<DoctorMove>().Punch();
        animator.GetComponent<DoctorMove>().PunchHit();

        if (doctormove.isAttacking)
        {
            doctormove.anim.Play("DoctorAttack");
        }
        else
        {
            doctormove.anim.Play("DoctorWalk");
        }
       
    }
      

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (!doctormove.isAttacking)
        {
            doctormove.anim.Play("DoctorWalk");
        }
        else
        {
            doctormove.anim.Play("DoctorAttack");
        }

    }

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
