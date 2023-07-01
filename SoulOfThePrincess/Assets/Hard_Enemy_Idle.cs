using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hard_Enemy_Idle : StateMachineBehaviour
{

    Transform player;
    Rigidbody2D rb;

    public float detectionRange = 1f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       player = GameObject.FindGameObjectWithTag("Player").transform;
       rb = animator.GetComponent<Rigidbody2D>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       if (Vector2.Distance(player.position, rb.position) <= detectionRange)
       {
         animator.SetTrigger("player_detected");
       }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       animator.ResetTrigger("player_detected");
    }
}
