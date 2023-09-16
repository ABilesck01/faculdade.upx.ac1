using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenBehaviour : StateMachineBehaviour
{
    [SerializeField] private Vector2 minMaxTimeToAct;

    private static int eat = Animator.StringToHash("eat");
    private static int look = Animator.StringToHash("look");

    [SerializeField] private float timeToAct = 0;
    [SerializeField] private float currentTime = 0;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timeToAct = Random.Range(minMaxTimeToAct.x, minMaxTimeToAct.y);
        currentTime = 0;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        currentTime += Time.deltaTime;
        if (currentTime > timeToAct)
        {
            if(Random.value < 0.5f)
            {
                animator.SetTrigger(eat);
            }
            else
            {
                animator.SetTrigger(look);
            }
        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger(eat);
        animator.ResetTrigger(look);
        currentTime = 0;
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
