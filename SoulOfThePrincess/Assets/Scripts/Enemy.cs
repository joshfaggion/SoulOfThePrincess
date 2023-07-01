using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{


    // Point B has to be on the right, Point A on the left

    public Vector2 pointA;
    public Vector2 pointB;
    private Rigidbody2D rb;
    private Transform currentDestination;
    private string currentDirection;

    public float speed;

    public Animator anim;

    public float KBForce = 5f;
    public float KBCounter;
    public float KBTotalTime = 0.2f;

    public bool KnockFromRight;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // anim = GetComponent<Animator>();

        // these decide which way the enemy will move
        currentDestination = new GameObject().transform;
        currentDestination.position = pointB;
        currentDirection = "right";
    }

    void Update()
    {
        // either take knockback or allow movement
        if (KBCounter <= 0)
        {   

            // make the character move in the correct direction
            float xDiff = transform.position.x - currentDestination.position.x;
            if(currentDirection == "right") {
                if (xDiff > 0f)
                {
                    currentDirection = "left";
                    transform.eulerAngles = new Vector3(0f, 180f, 0f);
                    currentDestination.position = pointA;
                }
                else
                {
                    rb.velocity = new Vector2(speed, 0);
                }
                
            } else {
                if (xDiff < 0f)
                {
                    currentDestination.position = pointB;
                    currentDirection = "right";
                    transform.eulerAngles = new Vector3(0f, 0f, 0f);
                } else
                {
                    rb.velocity = new Vector2(-speed, 0);
                }
            }
        }
        else
        {
            if (KnockFromRight == true)
            {
                rb.velocity = new Vector2(-KBForce, .8f);
            }
            if (KnockFromRight == false)
            {
                rb.velocity = new Vector2(KBForce, .8f);
            }
            KBCounter -= Time.deltaTime;
        }
    }
        

        /*
        // set the new enemy destination if it gets close to one of the points
        if(Vector3.Distance(transform.position, currentDestination.position) < 1f && currentDirection == "right")
        {
            // flip();

            currentDestination.position = pointA;
            currentDirection = "left";
        }
        if(Vector3.Distance(transform.position, currentDestination.position) < 1f && currentDirection == "left")
        {
            // flip();
            
            currentDestination.position = pointB;
            currentDirection = "right";
        }
        */

    // give the update function the correct variables to receive knockback
    public void TakeKnockback(string direction) {
        anim.SetTrigger("hurt");

        KBCounter = KBTotalTime;
        if (direction == "left")
        {
            KnockFromRight = true;
        }
        if (direction == "right")
        {
            KnockFromRight = false;
        }
    }

    // make the enemy model flip directions on the X axis
    // private void flip() {
    //     Vector3 localScale = transform.localScale;
    //     localScale.x *= -1;
    //     transform.localScale = localScale;
    // }
}
