using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    public Animator anim;
    [SerializeField] private SimpleFlash flashEffect;

    public int maxHealth = 120;
    public int currentHealth;

    public GameObject AudioObject;
    AudioManager audio;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        audio = AudioObject.GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;

        if (currentHealth <= 0) {
            audio.PlaySound("barrel_death");
            anim.SetTrigger("death");
        } else {
            audio.PlaySound("barrel_hit");
        
            flashEffect.Flash();
        }
    }

    void Die() {
        Destroy(gameObject);
    }
}
