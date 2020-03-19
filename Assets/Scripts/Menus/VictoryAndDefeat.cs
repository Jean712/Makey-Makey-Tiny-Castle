using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryAndDefeat : MonoBehaviour
{
    [Header("Basic Configuration")]
    public KeyCode[] myInputs;
    
    void Update()
    {
        if (Input.GetKeyDown(myInputs[0]))
        {
            SceneManager.LoadScene("Main Menu");
        }

        if (Input.GetKeyDown(myInputs[1]))
        {
            SceneManager.LoadScene(GameManager.currentLevel);
        }
    }
}
