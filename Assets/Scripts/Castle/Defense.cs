using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Defense : MonoBehaviour
{
    [HideInInspector]
    public bool onSlot;
    [HideInInspector]
    public bool onCooler;
    [HideInInspector]
    public bool active;
    [HideInInspector]
    public bool crankActive;
    [HideInInspector]
    public GameObject enemyToKill;
    [HideInInspector]
    public GameObject walkingEnemyToKill;
    [HideInInspector]
    public GameObject flyingEnemyToKill;
    [HideInInspector]
    public AudioSource adsr;

    [Header("Developer Only")]          // Developer Only //
    public bool canHeat = false;        // Developer Only //
    [Range(0, 101)]                     // Developer Only //
    public float heat;

    [Header("Basic Configuration")]
    public ParticleSystem ptcl;
    public Animator amtr;
    public float timeBeforeShooting = 1;
    private float timer1;
    public Transform myLocation;
    public KeyCode[] myInputs;
    public KeyCode pauseInput;
    public float maxHeat;
    public GameObject cooldownBar;
    public GameObject overheatUI;
    public float coolingSpeed = 1;
    public float coolingSpeedOnBooster = 2;
    private bool overheated;
    private bool exitOverheat;
    public float heatAfterCancel;
    public float overheatedCancelTime;
    private float timer2;
    public GameObject tutorialUI;

    [Header("Audio")]
    public AudioClip impact;
    public AudioClip shoot;
    public AudioClip overheat;
    public AudioClip recovery;

    private void Awake()
    {
        adsr = GetComponent<AudioSource>();

        timer1 = timeBeforeShooting;
        timer2 = overheatedCancelTime;

        cooldownBar.GetComponent<Slider>().maxValue = maxHeat;
        overheatUI.SetActive(false);

        if (SceneManager.GetActiveScene().name == "Level1")
        {
            tutorialUI.SetActive(false);
        }
    }

    private void Update()
    {
        // Activation et désactivation.
        for (int i = 0; i < myInputs.Length; i++)
        {
            if (Input.GetKeyDown(myInputs[i]))
            {
                amtr.Play("Invoke");
            }

            if (onSlot && !overheated)
            {
                if (Input.GetKey(myInputs[i]))
                {
                    timer1 -= Time.deltaTime;

                    if (timer1 <= 0)
                    {
                        active = true;
                    }
                }
            }

            if (Input.GetKeyUp(myInputs[i]))
            {
                active = false;
                timer1 = timeBeforeShooting;
            }
        }

        //Surchauffe et refroidissement.
        if (canHeat)                                                    // Developer Only //
        {
            if (timer2 == overheatedCancelTime)
            {
                if (!active)
                {
                    heat -= coolingSpeed * Time.deltaTime;
                }

                if (onCooler)
                {
                    heat -= coolingSpeedOnBooster * Time.deltaTime;
                }

                if (heat < 0)
                {
                    heat = 0;
                }

                if (heat >= maxHeat)
                {
                    if (GameManager.soundOn)
                    {
                        adsr.PlayOneShot(overheat);
                    }

                    overheated = true;
                }
            }

            // Récupération.
            if (!overheated)
            {
                timer2 = overheatedCancelTime;
            }

            if (overheated)
            {
                // Tutoriel.
                if (SceneManager.GetActiveScene().name == "Level1" && !GameManager.overheatTutorialSeen && !GameManager.tutorialActive)
                {
                    GameManager.tutorialActive = true;
                    tutorialUI.SetActive(true);
                    Time.timeScale = 0;
                }

                active = false;
                overheatUI.SetActive(true);

                if (!exitOverheat)
                {
                    heat = maxHeat;
                }

                if (!onSlot)
                {
                    timer2 -= Time.deltaTime;

                    if (timer2 <= 0)
                    {
                        exitOverheat = true;
                    }
                }
            }

            if (exitOverheat)
            {
                heat = Mathf.Lerp(heat, heatAfterCancel, 0.1f);

                if (heat >= heatAfterCancel && heat <= heatAfterCancel + 0.1f)
                {
                    adsr.PlayOneShot(recovery);
                    overheated = false;
                    overheatUI.SetActive(false);
                    exitOverheat = false;
                }
            }
        }                                                               //Developer Only //

        // Fin tutoriel.
        if (tutorialUI.activeSelf && Input.GetKeyDown(pauseInput))
        {
            tutorialUI.SetActive(false);
            Time.timeScale = 1;
            GameManager.overheatTutorialSeen = true;

            StartCoroutine(EndTutorial(0.5f));
        }

        cooldownBar.GetComponent<Slider>().value = heat;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Slot>() != null)
        {
            ptcl.Play();

            if (GameManager.soundOn)
            {
                adsr.PlayOneShot(impact);
            }
        }
    }

    IEnumerator EndTutorial(float time)
    {
        yield return new WaitForSecondsRealtime(time);

        GameManager.tutorialActive = false;
    }
}
