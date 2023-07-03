using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Specialized;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    private SpriteRenderer sprite;
    public int health = 3;
    private bool invincible = false;
    private float invincibleCooldown = 1f;
    private float currentCooldown = 0;

    public GameObject AudioObject;
    AudioManager audio;

    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 7f;
    public Image healthIcon1;
    public Image healthIcon2;
    public Image healthIcon3;
    public Sprite fullSprite;
    public Sprite noneSprite;

    public float KBForce;
    public float KBCounter;
    public float KBTotalTime;

    public bool KnockFromRight;

    public Vector2 spawnLocation = new Vector2(36, -8);

    private enum MovementState
    {
        idle,
        run,
        up,
        down
    } 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

        audio = AudioObject.GetComponent<AudioManager>();
        Music.instance.PlayMusic();
    }

    // Update is called once per frame
    void Update()
    {
        float movX = Input.GetAxisRaw("Horizontal") * speed;

        if (KBCounter <= 0) 
        {
            rb.velocity = new Vector2(movX, rb.velocity.y);
            
            if (Input.GetKeyDown(KeyCode.W) && onGround())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        } 
        else
        {
            if (KnockFromRight == true)
            {
                rb.velocity = new Vector2(-KBForce, KBForce / 2f);
            }
            if (KnockFromRight == false)
            {
                rb.velocity = new Vector2(KBForce, KBForce / 2f);
            }
            KBCounter -= Time.deltaTime;
        }

        
        AnimationUpdate(movX);
        if (currentCooldown > 0) currentCooldown -= Time.deltaTime;
        if (currentCooldown <= 0 && invincible)
        {
            invincible = false;
        }
    }

    void Step() {
        audio.PlaySound("footstep");
    }

    private void AnimationUpdate(float movX)
    {
        MovementState state;
        if (movX > 0f)
        {
            state = MovementState.run;
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        else if (movX < 0f)
        {
            state = MovementState.run;
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > 0.1f)
        {
            state = MovementState.up;
        } else if (rb.velocity.y < -0.1f)
        {
            state = MovementState.down;
        }

        anim.SetInteger("state", (int) state);
    }

    private bool onGround()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        string currentScene = SceneManager.GetActiveScene().name;

        if (other.CompareTag("patrol_enemy"))
        {
            TakeDamage(other);            
        } else if (other.CompareTag("Door")) {
            if (currentScene == "Level1") {
                TransitionToScene("CutScene2");
            } else {
                TransitionToScene("Win");
            }
        }
        if (other.CompareTag("checkpoint")) {
            spawnLocation = other.gameObject.transform.position;
        }

        if (other.CompareTag("deathbox")) {
            Death();
        }
        if (other.CompareTag("Spikes"))
        {
            
            health--;

            anim.SetTrigger("hurt");
            
            audio.PlaySound("player_hurt");
            currentCooldown = invincibleCooldown;

            updateHealthIcon();
            
            invincible = true;
            if (health <= 0)
            {
                Death();
            } else {
                transform.position = spawnLocation;
            }
        }
    }

    public void TakeDamage(Collider2D other) {
        if (!invincible)
        {
            KBCounter = KBTotalTime;
            if (transform.position.x <= other.transform.position.x)
            {
                KnockFromRight = true;
            }
            if (transform.position.x > other.transform.position.x)
            {
                KnockFromRight = false;
            }

            health--;

            anim.SetTrigger("hurt");
            audio.PlaySound("player_hurt");

            currentCooldown = invincibleCooldown;
            
            updateHealthIcon();
            if (health <= 0)
            {   
                Death();
                
                // SceneManager.LoadScene("Menu");
            }
            invincible = true;
        }
    }

    private void Death() {
        string currentScene = SceneManager.GetActiveScene().name;
        audio.PlaySound("death");

        KBCounter = 3f;

        if (currentScene == "Level1") {
            TransitionToScene("Level1");
        } else if (currentScene == "Level2") {
            TransitionToScene("Level2");
        } else if (currentScene == "SFX Test Level") {
            TransitionToScene("SFX Test Level");
        }

        
    }

    void TransitionToScene(string sceneName) {
        GameObject.Find("Canvas/LevelLoader").GetComponent<LevelLoader>().LoadLevel(sceneName);
    }

    private void updateHealthIcon()
    {
        if (health == 3)
        {
            healthIcon1.sprite = fullSprite;
            healthIcon2.sprite = fullSprite;
            healthIcon3.sprite = fullSprite;
        } 
        else if (health == 2)
        {
            healthIcon1.sprite = fullSprite;
            healthIcon2.sprite = fullSprite;
            healthIcon3.sprite = noneSprite;
        }
        else if (health == 1)
        {
            healthIcon1.sprite = fullSprite;
            healthIcon2.sprite = noneSprite;
            healthIcon3.sprite = noneSprite;
        } else
        {
            healthIcon1.sprite = noneSprite;
            healthIcon2.sprite = noneSprite;
            healthIcon3.sprite = noneSprite;
        }
    }
}
