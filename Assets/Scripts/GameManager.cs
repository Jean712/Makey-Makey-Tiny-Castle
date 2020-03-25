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
    public GameObject spawner;
    public GameObject slot1;
    public GameObject slot2;
    public KeyCode pauseInput;
    private KeyCode leftInput;
    public GameObject bellows1;
    private KeyCode rightInput;
    public GameObject bellows2;
    public GameObject gameUI;
    public GameObject pauseUI;
    public GameObject mainCamera;
    public static bool isPaused = false;
    private bool soundOn = true;
    public static int currentLevel = 3;

    private void Awake()
    {
        pauseUI.SetActive(false);

        leftInput = bellows1.GetComponent<D_Bellows>().myInput;
        rightInput = bellows2.GetComponent<D_Bellows>().myInput;
    }

    private void Update()
    {
        // Victoire.
        if (spawner.GetComponent<Spawner>().round > 12)
        {
            if (slot1.GetComponent<Slot>().enemiesQueue.Count <= 0 || slot2.GetComponent<Slot>().enemiesQueue.Count <= 0)
            {
                StartCoroutine(Victory(3));
            }
        }

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

            if (Input.GetKeyDown(leftInput))
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
            if (Input.GetKeyDown(pauseInput))
            {
                timeScale = 0;

                gameUI.SetActive(false);
                pauseUI.SetActive(true);

                isPaused = true;
            }
        }
    }

    IEnumerator Victory(float time)
    {
        currentLevel++;

        if (currentLevel >= 6)
        {
            currentLevel = 3;
        }

        yield return new WaitForSeconds(time);

        SceneManager.LoadScene("Victory");
    }
}
