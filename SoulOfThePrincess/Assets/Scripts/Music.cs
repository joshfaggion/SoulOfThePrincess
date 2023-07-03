using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{
    private AudioSource audio;
    public static Music instance;

    public AudioClip MenuMusic;
    public float volume = .8f;

    void Awake() {
        if (instance == null) {
            instance = this;
            // totalObjects = 0;
            DontDestroyOnLoad(gameObject);
        }
        else if(instance != this) {
            Destroy(gameObject);
        }

        audio = GetComponent<AudioSource>();
        audio.volume = volume;
        PlayMusic();
    }

    public void PlayMusic()
    {
        if (audio.isPlaying) return;

        string currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == "Menu") {
            audio.clip = MenuMusic;
            audio.Play();
        } else if (currentScene == "Level1") {
            // Play level one music
        }
        
    }

    public void StopMusic()
    {
        audio.Stop();
    }
}