using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public Animator transition;

    public float transitionTime = 1.0f;

    // Update is called once per frame
    void Awake() {
    }

    void Update()
    {
        
    }

    public void LoadLevel(string levelName) {
        StartCoroutine(TransitionOut(levelName));
    }

    IEnumerator TransitionOut(string levelName) {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);
        
        SceneManager.LoadScene(levelName);
    }
}
