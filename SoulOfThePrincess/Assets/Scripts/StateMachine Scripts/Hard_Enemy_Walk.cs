using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hard_Enemy_Walk : StateMachineBehaviour
{

    public float speed = 2.5f;
    public float attackRange = 3f;

    Transform player;
    Rigidbody2D rb;

    Hard_Enemy hard_enemy;
    Hard_Enemy_Weapon hard_enemy_weapon;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       player = GameObject.FindGameObjectWithTag("Player").transform;
       rb = animator.GetComponent<Rigidbody2D>();

       hard_enemy = animator.GetComponent<Hard_Enemy>();
       hard_enemy_weapon = animator.GetComponent<Hard_Enemy_Weapon>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      hard_enemy.LookAtPlayer();

      if (!hard_enemy_weapon.stunned) {
         Vector2 target = new Vector2(player.position.x, rb.position.y);
         Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
         rb.MovePosition(newPos);

         if (Vector2.Distance(player.position, rb.position) <= attackRange)
         {
            animator.SetTrigger("attack");
            rb.velocity = new Vector2(0f, 0f);
         }
      }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       animator.ResetTrigger("attack");
    }
}
