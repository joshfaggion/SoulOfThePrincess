using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    private AudioSource audio;

    public AudioClip PatrolEnemyHurtSFX;
    public AudioClip PatrolEnemyKilledSFX;
    public AudioClip EnemyHitSFX;

    public AudioClip SwordSwingSFX;
    public AudioClip LeverSFX;
    public AudioClip DoorOpenSFX;

    public AudioClip BarrelHitSFX;
    public AudioClip BarrelKilledSFX;

    public AudioClip[] FootstepsSFX;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void PlaySound(string name) {
        if (name == "patrol_enemy_hurt") {
            PlayClip(PatrolEnemyHurtSFX, .1f);
        }
        if (name == "patrol_enemy_killed") {
            PlayClip(PatrolEnemyKilledSFX, .08f);
        }
        if (name == "enemy_hit") {
            PlayClip(EnemyHitSFX, 0.1f);
        }
        if (name == "sword_swing") {
            PlayClip(SwordSwingSFX, .03f);
        }
        if (name == "lever") {
            PlayClip(LeverSFX, .1f);
        }
        if (name == "door_open") {
            PlayClip(DoorOpenSFX, .3f);
        }
        if (name == "barrel_hit") {
            PlayClip(BarrelHitSFX, .07f);
        }
        if (name == "barrel_death") {
            PlayClip(BarrelKilledSFX, .08f);
        }

        if (name == "footstep") {
            PlayFootstep();
        }
    }

    public void PlayClip(AudioClip clip, float volume) {
        audio.PlayOneShot(clip, volume);
    }

    void PlayFootstep() {
        audio.PlayOneShot(FootstepsSFX[Random.Range(0, FootstepsSFX.Length)], 0.02f);
    }
}
