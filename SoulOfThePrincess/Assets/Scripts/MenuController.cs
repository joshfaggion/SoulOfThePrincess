using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;


public class MenuController : MonoBehaviour
{
    public Button play;
    public Button help;
    public Button quit;
    // Start is called before the first frame update
    void Start()
    {
        play.onClick.AddListener(playPressed);
        help.onClick.AddListener(helpPressed);
        quit.onClick.AddListener(quitPressed);
    }

    void playPressed()
    {
        SceneManager.LoadScene("Level1");
    }
    void helpPressed()
    {
        ;
    }
    void quitPressed()
    {
        Application.Quit();
    }
}
