using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    void Awake() {
        if (instance == null) {
            instance = this;
            // totalObjects = 0;
            DontDestroyOnLoad(gameObject);
        }
        else if(instance != this) {
            Destroy(gameObject);
        }
    }
    
    // public void GameOver() {
    //     string currentScene = SceneManager.GetActiveScene().name;
    //     string nextScene = "";
    //     switch(currentScene)
    //     {
    //         case "Level-1":
    //             nextScene = "Level-2";
    //             break;
    //         case "Level-2":
    //             nextScene = "Win";
    //             break;
    //     }
    
    public void NextLevel() {
        // Finds any active LevelLoader and runs its transition Coroutine 
        GameObject.Find("Canvas/LevelLoader").GetComponent<LevelLoader>().LoadLevel("Level1");

        // SceneManager.LoadScene(nextScene);
    }
}
