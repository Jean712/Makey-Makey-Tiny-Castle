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
    public KeyCode leftInput;
    public GameObject bellows1;
    private KeyCode rightInput;
    public GameObject bellows2;
    private KeyCode mainMenuInput;
    public GameObject gameUI;
    public GameObject pauseUI;
    public GameObject mainCamera;
    public static bool isPaused = false;
    private bool soundOn = true;

    private void Awake()
    {
        pauseUI.SetActive(false);

        mainMenuInput = bellows1.GetComponent<D_Bellows>().myInput;
        rightInput = bellows2.GetComponent<D_Bellows>().myInput;
    }

    private void Update()
    {
        // Pause.
        Time.timeScale = timeScale;

        if (isPaused)
        {
            if (!Castle.loose)
            {
                if (Input.GetKeyDown(leftInput))
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
                if (Input.GetKeyDown(rightInput))
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
                pauseUI.SetActive(false);
                gameUI.SetActive(false);

                if (Input.GetKeyDown(leftInput))
                {
                    SceneManager.LoadScene("Main Menu");
                    Castle.loose = false;
                }

                if (Input.GetKeyDown(rightInput))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    Castle.loose = false;
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(leftInput))
            {
                timeScale = 0;

                gameUI.SetActive(false);
                pauseUI.SetActive(true);

                isPaused = true;
            }
        }

        Debug.Log(isPaused);
        Debug.Log(SceneManager.GetActiveScene().name);
    }
}
