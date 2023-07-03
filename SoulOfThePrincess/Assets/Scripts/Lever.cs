using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public Animator anim;
    public Door door;

    public GameObject AudioObject;
    AudioManager audio;

    private bool used = false;

    void Start() {
        audio = AudioObject.GetComponent<AudioManager>();
    }

    public void LeverHit() {
        
        audio.PlaySound("lever");

        if (!used) {
            audio.PlaySound("door_open");
            anim.SetTrigger("hit");

            door.Open();
        }

        used = true;
    }
}
