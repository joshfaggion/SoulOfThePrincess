using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public Animator anim;
    public BoxCollider2D[] colliders;

    public GameObject AudioObject;
    AudioManager audio;

    public int maxHealth = 120;
    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        colliders = GetComponents<BoxCollider2D>();
        audio = AudioObject.GetComponent<AudioManager>();
    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;

        if (currentHealth <= 0) {

            if (gameObject.name.Contains("PatrollingEnemy")) {
                audio.PlaySound("patrol_enemy_killed");

                foreach(BoxCollider2D collider in colliders) {
                    Debug.Log(colliders.Length);
                    collider.isTrigger = false;
                }
            } else if (gameObject.name.Contains("Hard_Enemy")) {
                audio.PlaySound("hard_enemy_killed");
            }
            
            anim.SetTrigger("death");

            foreach(BoxCollider2D collider in colliders) {
                collider.enabled = !collider.enabled;
            }
        } else {
            audio.PlaySound("enemy_hit");
            if (gameObject.name.Contains("PatrollingEnemy")) {
                audio.PlaySound("patrol_enemy_hurt");
            } else if (gameObject.name.Contains("Hard_Enemy")) {
                audio.PlaySound("hard_enemy_hurt");
            }
        }
    }

    void Die() {
        Destroy(gameObject);
    }
}
