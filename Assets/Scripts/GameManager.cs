using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Developer Only")]  // Developer Only //
    [Range(0, 100)]             // Developer Only //
    public float timeScale = 1;

    [Header("Basic Configuration")]
    public KeyCode pauseInput;
    public GameObject bellows1;
    private KeyCode soundInput;
    public GameObject bellows2;
    private KeyCode mainMenuInput;
    public GameObject gameUI;
    public GameObject pauseUI;
    public GameObject mainCamera;
    private bool isPaused = false;
    private bool soundOn = true;

    private void Awake()
    {
        pauseUI.SetActive(false);

        soundInput = bellows1.GetComponent<D_Bellows>().myInput;
        mainMenuInput = bellows2.GetComponent<D_Bellows>().myInput;
    }

    private void Update()
    {
        // Pause.
        Time.timeScale = timeScale;

        if (isPaused)
        {
            if (Input.GetKeyDown(pauseInput))
            {
                timeScale = 1;

                pauseUI.SetActive(false);
                gameUI.SetActive(true);

                isPaused = false;
            }

            if (Input.GetKeyDown(mainMenuInput))
            {
                SceneManager.LoadScene("Main Menu");
            }

            // Sound on & off.
            if (Input.GetKeyDown(soundInput))
            {
                if (soundOn)
                {
                    mainCamera.GetComponent<AudioListener>().enabled = false;

                    soundOn = false;
                }
                else
                {
                    mainCamera.GetComponent<AudioListener>().enabled = true;

                    soundOn = true;
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(pauseInput))
            {
                timeScale = 0;

                gameUI.SetActive(false);
                pauseUI.SetActive(true);

                isPaused = true;
            }
        }
    }
}
