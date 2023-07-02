using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EndScreenButtons : MonoBehaviour
{
    public Button menu;
    // Start is called before the first frame update
    void Start()
    {
        menu.onClick.AddListener(menuPressed);
    }

    void menuPressed()
    {
        SceneManager.LoadScene("Menu");
    }





    // Update is called once per frame
    void Update()
    {
        
    }
}
