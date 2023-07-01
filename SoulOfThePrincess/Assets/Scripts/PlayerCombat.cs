using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;
    public Transform attackPoint;

    public int attackDamage = 40;
    public float attackRange = 0.5f;
    public float attackRate = 2f;

    float nextAttackTime = 0f;

    public LayerMask enemyLayers;


    void Update()
    {
        if (Time.time >= nextAttackTime) 
        {
            if(Input.GetKeyDown(KeyCode.Space)) 
            {
                animator.SetTrigger("attack");
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }

        
    }

    void Attack() {
        

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies) {

            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
            
            // tell the enemy which way to receive knockback from
            string direction = "";
            if (transform.position.x <= enemy.transform.position.x)
            {
                direction = "right";
            }
            if (transform.position.x > enemy.transform.position.x)
            {
                direction = "left";
            }

            if (enemy.name.Contains("Hard_Enemy")) {
                enemy.GetComponent<Hard_Enemy_Weapon>().TakeKnockback(direction);
            } else {
                enemy.GetComponent<Enemy>().TakeKnockback(direction);
            }
        }
    }

    void OnDrawGizmosSelected() {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
