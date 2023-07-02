using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;
    public Transform attackPoint;

    public GameObject AudioObject;
    AudioManager audio;

    public int attackDamage = 40;
    public float attackRange = 0.5f;
    public float attackRate = 2f;

    float nextAttackTime = 0f;

    public LayerMask enemyLayers;

    void Start() {
        audio = AudioObject.GetComponent<AudioManager>();
    }


    void Update()
    {
        if (Time.time >= nextAttackTime) 
        {
            if(Input.GetKeyDown(KeyCode.Space)) 
            {
                audio.PlaySound("sword_swing");
                animator.SetTrigger("attack");
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }

        
    }

    void Attack() {
        

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies) {
            string direction = "";

            if (!enemy.name.Contains("Barrel") && !enemy.name.Contains("Lever")) {
                enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
                
                // tell the enemy which way to receive knockback from
                if (transform.position.x <= enemy.transform.position.x)
                {
                    direction = "right";
                }
                if (transform.position.x > enemy.transform.position.x)
                {
                    direction = "left";
                }
            }
            
            if (enemy.name.Contains("Hard_Enemy")) {
                enemy.GetComponent<Hard_Enemy_Weapon>().TakeKnockback(direction);
            } else if (enemy.name.Contains("Enemy")) {
                enemy.GetComponent<Enemy>().TakeKnockback(direction);
            } else if (enemy.name.Contains("Barrel")) {
                enemy.GetComponent<Barrel>().TakeDamage(attackDamage);
            } else if (enemy.name.Contains("Lever")) {
                enemy.GetComponent<Lever>().LeverHit();
            }
        }
    }

    void OnDrawGizmosSelected() {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
