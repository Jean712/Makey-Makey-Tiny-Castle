using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private AudioSource adsr;

    [Header("Basic Configuration")]
    public GameObject spawner;
    public GameObject slot1;
    public GameObject slot2;
    public KeyCode pauseInput;
    private KeyCode leftInput;
    public GameObject bellows1;
    private KeyCode rightInput;
    public GameObject bellows2;
    public KeyCode[] canonInputs;
    private bool canonTutorialSeen;
    public KeyCode[] catapultInputs;
    private bool catapultTutorialSeen;
    public KeyCode[] superCrossbowInputs;
    private bool superCrossbowTutorialSeen;
    public KeyCode[] mageTowerInputs;
    private bool mageTowerTutorialSeen;
    public static bool overheatTutorialSeen;
    public GameObject gameUI;
    public GameObject pauseUI;
    public GameObject[] tutorialUIs;
    public GameObject cross;
    public GameObject mainCamera;
    public static bool isPaused = false;
    public static bool soundOn = true;
    public static int currentLevel = 3;
    private bool normalize;

    private void Awake()
    {
        adsr = mainCamera.GetComponent<AudioSource>();
        leftInput = bellows1.GetComponent<D_Bellows>().myInput;
        rightInput = bellows2.GetComponent<D_Bellows>().myInput;

        pauseUI.SetActive(false);

        if (SceneManager.GetActiveScene().name == "Level1")
        {
            for (int i = 0; i < tutorialUIs.Length; i++)
            {
                tutorialUIs[i].SetActive(false);
            }
        }
    }

    private void Update()
    {
        Debug.Log(currentLevel);

        // Victoire.
        if (spawner.GetComponent<Spawner>().round >= 13)
        {
            if (slot1.GetComponent<Slot>().actualEnemy == null && slot2.GetComponent<Slot>().actualEnemy == null)
            {
                StartCoroutine(Victory(3));
            }
        }

        // Pause.
        if (isPaused)
        {
            if (Input.GetKeyDown(pauseInput))
            {
                Time.timeScale = 1;

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
                    soundOn = false;
                }
                else
                {
                    soundOn = true;
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(pauseInput))
            {
                Time.timeScale = 0;

                gameUI.SetActive(false);
                pauseUI.SetActive(true);

                isPaused = true;
            }

            // Tutoriel.
            if (SceneManager.GetActiveScene().name == "Level1")
            {
                for (int i = 0; i < canonInputs.Length; i++)
                {
                    if (Input.GetKeyDown(canonInputs[i]) && !canonTutorialSeen)
                    {
                        StartCoroutine(CanonTutorial(7));
                        canonTutorialSeen = true;
                    }
                }

                for (int i = 0; i < catapultInputs.Length; i++)
                {
                    if (Input.GetKeyDown(catapultInputs[i]) && !catapultTutorialSeen)
                    {
                        StartCoroutine(CatapultTutorial(7));
                        catapultTutorialSeen = true;
                    }
                }

                for (int i = 0; i < superCrossbowInputs.Length; i++)
                {
                    if (Input.GetKeyDown(superCrossbowInputs[i]) && !superCrossbowTutorialSeen)
                    {
                        StartCoroutine(SuperCrossbowTutorial(7));
                        superCrossbowTutorialSeen = true;
                    }
                }

                for (int i = 0; i < mageTowerInputs.Length; i++)
                {
                    if (Input.GetKeyDown(mageTowerInputs[i]) && !mageTowerTutorialSeen)
                    {
                        StartCoroutine(MageTowerTutorial(7));
                        mageTowerTutorialSeen = true;
                    }
                }
            }
        }

        if (soundOn)
        {
            adsr.mute = false;
            cross.SetActive(false);
        }
        else
        {
            adsr.mute = true;
            cross.SetActive(true);
        }
    }

    IEnumerator Victory(float time)
    {
        if (!normalize)
        {
            currentLevel++;
            normalize = true;
        }

        if (currentLevel >= 6)
        {
            currentLevel = 3;
        }

        yield return new WaitForSeconds(time);

        SceneManager.LoadScene("Victory");
    }

    IEnumerator CanonTutorial(float time)
    {
        tutorialUIs[0].SetActive(true);
        Time.timeScale = 0;

        yield return new WaitForSecondsRealtime(time);

        tutorialUIs[0].SetActive(false);
        Time.timeScale = 1;
    }

    IEnumerator CatapultTutorial(float time)
    {
        tutorialUIs[1].SetActive(true);
        Time.timeScale = 0;

        yield return new WaitForSecondsRealtime(time);

        tutorialUIs[1].SetActive(false);
        Time.timeScale = 1;
    }

    IEnumerator SuperCrossbowTutorial(float time)
    {
        tutorialUIs[2].SetActive(true);
        Time.timeScale = 0;

        yield return new WaitForSecondsRealtime(time);

        tutorialUIs[2].SetActive(false);
        Time.timeScale = 1;
    }

    IEnumerator MageTowerTutorial(float time)
    {
        tutorialUIs[3].SetActive(true);
        Time.timeScale = 0;

        yield return new WaitForSecondsRealtime(time);

        tutorialUIs[3].SetActive(false);
        Time.timeScale = 1;
    }
}
