using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        
        if (currentScene == "CutSceneOne") {
            StartCoroutine(TransitionFromVideo("Level1", 22f));
        } else if (currentScene == "CutScene2") {
            Music.instance.PlayMusic();
            StartCoroutine(TransitionFromVideo("Level2", 22f));
        }
    }

    IEnumerator TransitionFromVideo(string sceneName, float cutsceneLength) {
        yield return new WaitForSeconds(cutsceneLength);
        
        TransitionToScene(sceneName);
    }

    void TransitionToScene(string sceneName) {
        GameObject.Find("Canvas/LevelLoader").GetComponent<LevelLoader>().LoadLevel(sceneName);
    }
}
