using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private AudioSource adsr;

    [Header("Basic Configuration")]
    public GameObject spawner;
    private bool finalRoundActivated;
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
    public static bool tutorialActive;
    public GameObject gameUI;
    public GameObject pauseUI;
    public GameObject progressionBar;
    private Image borderBlack;
    private Image skullBlack;
    public GameObject[] tutorialUIs;
    public GameObject cross;
    public GameObject mainCamera;
    public static bool isPaused = false;
    public static bool soundOn = true;
    public static int currentLevel = 3;
    private bool normalize;

    [Header("Audio")]
    public AudioClip level;
    public AudioClip finalRound;

    private void Awake()
    {
        adsr = mainCamera.GetComponent<AudioSource>();
        leftInput = bellows1.GetComponent<D_Bellows>().myInput;
        rightInput = bellows2.GetComponent<D_Bellows>().myInput;

        borderBlack = progressionBar.transform.Find("BorderBlack").GetComponent<Image>();
        skullBlack = progressionBar.transform.Find("SkullBlack").GetComponent<Image>();

        pauseUI.SetActive(false);

        if (SceneManager.GetActiveScene().name == "Level1")
        {
            for (int i = 0; i < tutorialUIs.Length; i++)
            {
                tutorialUIs[i].SetActive(false);
            }
        }

        adsr.PlayOneShot(level);
    }

    private void Update()
    {
        // Barre de progression.
        progressionBar.GetComponent<Slider>().value = Mathf.Lerp(progressionBar.GetComponent<Slider>().value, spawner.GetComponent<Spawner>().round - 1, 0.05f);

        // Victoire.
        if (spawner.GetComponent<Spawner>().round >= 13)
        {
            if (slot1.GetComponent<Slot>().actualEnemy == null && slot2.GetComponent<Slot>().actualEnemy == null)
            {
                StartCoroutine(Victory(3));
            }
        }

        // Musique manche finale.
        if (spawner.GetComponent<Spawner>().round == 11 && spawner.GetComponent<Spawner>().timer <= 7.5f)
        {
            bool lerpEnded = false;

            if (!finalRoundActivated)
            {
                Color tmp1 = borderBlack.color;
                tmp1.a = 1;

                borderBlack.color = Color.Lerp(borderBlack.color, tmp1, 0.05f);

                Color tmp2 = skullBlack.color;
                tmp2.a = 1;

                skullBlack.color = Color.Lerp(skullBlack.color, tmp2, 0.05f);

                if (!lerpEnded)
                {
                    adsr.volume = Mathf.Lerp(adsr.volume, 0, 0.05f);
                }

                if (adsr.volume >= 0 && adsr.volume <= 0.001f)
                {
                    lerpEnded = true;

                    adsr.volume = 0.3f;
                    adsr.Stop();
                    adsr.PlayOneShot(finalRound);

                    finalRoundActivated = true;
                }
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
            if (Input.GetKeyDown(pauseInput) && !tutorialActive)
            {
                Time.timeScale = 0;

                gameUI.SetActive(false);
                pauseUI.SetActive(true);

                isPaused = true;
            }

            // Tutoriel.
            if (SceneManager.GetActiveScene().name == "Level1" && !tutorialActive)
            {
                for (int i = 0; i < canonInputs.Length; i++)
                {
                    if (Input.GetKeyDown(canonInputs[i]) && !canonTutorialSeen)
                    {
                        tutorialActive = true;
                        tutorialUIs[0].SetActive(true);
                        Time.timeScale = 0;
                    }
                }

                for (int i = 0; i < catapultInputs.Length; i++)
                {
                    if (Input.GetKeyDown(catapultInputs[i]) && !catapultTutorialSeen)
                    {
                        tutorialActive = true;
                        tutorialUIs[1].SetActive(true);
                        Time.timeScale = 0;
                    }
                }

                for (int i = 0; i < superCrossbowInputs.Length; i++)
                {
                    if (Input.GetKeyDown(superCrossbowInputs[i]) && !superCrossbowTutorialSeen)
                    {
                        tutorialActive = true;
                        tutorialUIs[2].SetActive(true);
                        Time.timeScale = 0;
                    }
                }

                for (int i = 0; i < mageTowerInputs.Length; i++)
                {
                    if (Input.GetKeyDown(mageTowerInputs[i]) && !mageTowerTutorialSeen)
                    {
                        tutorialActive = true;
                        tutorialUIs[3].SetActive(true);
                        Time.timeScale = 0;
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

        // Fin tutoriels.
        for (int i = 0; i < tutorialUIs.Length; i++)
        {
            if (SceneManager.GetActiveScene().name == "Level1" && tutorialUIs[i].activeSelf && Input.GetKeyDown(pauseInput))
            {
                tutorialUIs[i].SetActive(false);
                Time.timeScale = 1;

                switch (i)
                {
                    case 0:
                        canonTutorialSeen = true;
                        break;

                    case 1:
                        catapultTutorialSeen = true;
                        break;

                    case 2:
                        superCrossbowTutorialSeen = true;
                        break;

                    case 3:
                        mageTowerTutorialSeen = true;
                        break;
                }

                StartCoroutine(EndTutorial(0.5f));
            }
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

    IEnumerator EndTutorial(float time)
    {
        yield return new WaitForSecondsRealtime(time);

        tutorialActive = false;
    }
}
