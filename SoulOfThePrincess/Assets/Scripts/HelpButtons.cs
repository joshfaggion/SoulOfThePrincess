using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HelpButtons : MonoBehaviour
{
    public GameObject Screen;
    public GameObject ScreenOne;
    public GameObject ScreenTwo;

    


    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnClickMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void OnClickOpenHelpScreen()
    {
        Screen.SetActive(true);
    }
    public void OnClickScreenOne()
    {
        ScreenOne.SetActive(true);
        ScreenTwo.SetActive(false);
    }
    public void OnClickScreenTwo()
    {
        ScreenOne.SetActive(false);
        ScreenTwo.SetActive(true);
    }
    public void OnClickCloseScreen()
    {
        Screen.SetActive(false);
        ScreenOne.SetActive(true);
        ScreenTwo.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
