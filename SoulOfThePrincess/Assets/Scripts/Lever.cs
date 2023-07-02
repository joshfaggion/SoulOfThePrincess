using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public Animator anim;
    public Door door;

    public void LeverHit() {
        Debug.Log("hit");
        anim.SetTrigger("hit");

        door.Open();
    }
}
