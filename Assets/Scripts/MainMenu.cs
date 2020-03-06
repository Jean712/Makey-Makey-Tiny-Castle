using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Basic Configuration")]
    public KeyCode startInput;
    
    void Update()
    {
        if (Input.GetKeyDown(startInput))
        {
            SceneManager.LoadScene("Jean");
        }
    }
}
