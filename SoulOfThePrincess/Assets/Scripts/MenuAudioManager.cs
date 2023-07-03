using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAudioManager : MonoBehaviour
{

    private AudioSource audio;

    public AudioClip ClickSFX;
    public AudioClip StartSFX;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void onMenuClick() {
        PlayClip(ClickSFX, 0.6f);
    }

    public void onStartClick() {
        PlayClip(StartSFX, 0.3f);
    }

    public void PlayClip(AudioClip clip, float volume) {
        audio.PlayOneShot(clip, volume);
    }
}
