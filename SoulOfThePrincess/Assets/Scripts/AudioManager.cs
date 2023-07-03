using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    private AudioSource audio;

    public AudioClip PatrolEnemyHurtSFX;
    public AudioClip PatrolEnemyKilledSFX;
    public AudioClip EnemyHitSFX;
    public AudioClip HardEnemyHurtSFX;
    public AudioClip HardEnemyKilledSFX;

    public AudioClip PlayerHurtSFX;
    public AudioClip PlayerDeathSFX;

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
        // combat sounds
        if (name == "patrol_enemy_hurt") {
            PlayClip(PatrolEnemyHurtSFX, .1f);
        }
        if (name == "patrol_enemy_killed") {
            PlayClip(PatrolEnemyKilledSFX, .05f);
        }
        if (name == "enemy_hit") {
            PlayClip(EnemyHitSFX, 0.1f);
        }
        if (name == "hard_enemy_hurt") {
            PlayClip(HardEnemyHurtSFX, 0.1f);
        }
        if (name == "hard_enemy_killed") {
            PlayClip(HardEnemyKilledSFX, 0.1f);
        }
        if (name == "sword_swing") {
            PlayClip(SwordSwingSFX, .03f);
        }
        if (name == "player_hurt") {
            PlayClip(EnemyHitSFX, 0.1f);
            PlayClip(PlayerHurtSFX, .007f);
        }
        if (name == "death") {
            PlayClip(PlayerDeathSFX, 0.2f);
        }


        // interaction sounds
        if (name == "lever") {
            PlayClip(LeverSFX, .1f);
        }
        if (name == "door_open") {
            PlayClip(DoorOpenSFX, .3f);
        }
        if (name == "barrel_hit") {
            PlayClip(BarrelHitSFX, .02f);
        }
        if (name == "barrel_death") {
            PlayClip(BarrelKilledSFX, .04f);
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
