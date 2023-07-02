using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;


public class MenuController : MonoBehaviour
{
    public GameObject Screen;
    public GameObject CredScreen;
    public Button play;
    public Button help;
    public Button quit;
    public Button cred;

    // Start is called before the first frame update
    void Start()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        play.onClick.AddListener(playPressed);
        help.onClick.AddListener(helpPressed);
        quit.onClick.AddListener(quitPressed);
        cred.onClick.AddListener(credPressed);
    }

    void playPressed()
    {
        TransitionToScene("CutSceneOne");
    }
    void helpPressed()
    {
        Screen.SetActive(true);
    }
    void quitPressed()
    {
        Application.Quit();
    }
    void credPressed()
    {
        if (CredScreen.activeSelf)
        {
            CredScreen.SetActive(false);
        }
        else
        {
            CredScreen.SetActive(true);
        }
    }

    void TransitionToScene(string sceneName) {
        GameObject.Find("Canvas/LevelLoader").GetComponent<LevelLoader>().LoadLevel(sceneName);
    }
}
