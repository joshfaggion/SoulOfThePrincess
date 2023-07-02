using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    public Animator anim;
    [SerializeField] private SimpleFlash flashEffect;

    public int maxHealth = 120;
    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;
        flashEffect.Flash();

        if (currentHealth <= 0) {
            anim.SetTrigger("death");

            // foreach(BoxCollider2D collider in colliders) {
            //     collider.enabled = !collider.enabled;
            // }
        }
    }

    void Die() {
        Destroy(gameObject);
    }
}
