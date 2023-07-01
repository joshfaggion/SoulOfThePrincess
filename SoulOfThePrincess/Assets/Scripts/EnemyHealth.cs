using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public Animator anim;
    public BoxCollider2D[] colliders;

    public int maxHealth = 120;
    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        colliders = GetComponents<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;

        if (currentHealth <= 0) {
            anim.SetTrigger("death");

            foreach(BoxCollider2D collider in colliders) {
                collider.enabled = !collider.enabled;
            }
        }
    }

    void Die() {
        Destroy(gameObject);
    }
}
