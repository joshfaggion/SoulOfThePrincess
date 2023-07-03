using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{
    private AudioSource audio;
    public static Music instance;

    public AudioClip MenuMusic;
    public AudioClip LevelMusic;
    public float volume = .8f;
    public AudioClip CutsceneMusic;

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
        
        PlayMusic();
    }

    public void PlayMusic()
    {
        audio.volume = volume;
        Debug.Log("Getting there");
        string currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == "Menu") {
            audio.volume = .02f;
            audio.clip = MenuMusic;
            audio.Play();
        } else if (currentScene == "Level1") {
            audio.volume = .03f;
            audio.clip = LevelMusic;
            audio.Play();
            Debug.Log("clip played");
        } else if (currentScene == "Level2") {
            audio.volume = .03f;
            audio.clip = LevelMusic;
            audio.Play();
        } else if (currentScene == "CutScene2") {
            audio.volume = .18f;
            audio.clip = CutsceneMusic;
            audio.Play();
        } else if (currentScene == "Win") {
            audio.volume = .03f;
            audio.clip = MenuMusic;
            audio.Play();
        }
        
    }

    public void StopMusic()
    {
        audio.Stop();
    }
}