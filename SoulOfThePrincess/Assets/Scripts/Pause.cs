using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject PauseMenu;



    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnClickPause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void OnClickMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
    public void OnClickResume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void OnClickQuit()
    {      
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
