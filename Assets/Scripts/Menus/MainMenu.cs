using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private AudioSource adsr;

    [Header("Basic Configuration")]
    public KeyCode[] myInputs;
    public GameObject mainCamera;

    private void Awake()
    {
        adsr = mainCamera.GetComponent<AudioSource>();

        if (GameManager.soundOn)
        {
            adsr.mute = false;
        }
        else
        {
            adsr.mute = true;
        }
    }

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
