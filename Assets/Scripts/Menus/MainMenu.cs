using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Basic Configuration")]
    public KeyCode[] myInputs;
    
    void Update()
    {
        if (Input.GetKeyDown(myInputs[0]))
        {
            Application.Quit();
        }
        
        if (Input.GetKeyDown(myInputs[1]))
        {
            SceneManager.LoadScene(GameManager.currentLevel);
        }
    }
}
