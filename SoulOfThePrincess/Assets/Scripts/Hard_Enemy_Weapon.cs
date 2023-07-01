using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hard_Enemy_Weapon : MonoBehaviour
{
	public Vector3 attackOffset;
	public float attackRange = 1f;
	public LayerMask attackMask;
    Collider2D enemyCollider;
    Rigidbody2D rb;

    public float KBForce;
    public float KBCounter;
    public float KBTotalTime;

    public bool stunned = false;

    public bool KnockFromRight;

    [SerializeField] private SimpleFlash flashEffect;
    [SerializeField] private KeyCode flashKey;

    void Start() {
        enemyCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if (KBCounter > 0) {
            stunned = true;
            if (KnockFromRight == true)
            {
                rb.velocity = new Vector2(-KBForce, .2f);
            }
            if (KnockFromRight == false)
            {
                rb.velocity = new Vector2(KBForce, .2f);
            }
            KBCounter -= Time.deltaTime;
        }
        stunned = false;  
    }

    public void TakeKnockback(string direction) {
        // anim.SetTrigger("hurt");

        // do flash here
        flashEffect.Flash();

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

	public void Attack()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);

		if (colInfo != null)
		{
			colInfo.GetComponent<PlayerMovement>().TakeDamage(enemyCollider);
		}
	}

	void OnDrawGizmosSelected()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Gizmos.DrawWireSphere(pos, attackRange);
	}
}