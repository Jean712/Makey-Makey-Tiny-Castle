using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VictoryAndDefeat : MonoBehaviour
{
    private AudioSource adsr;

    [Header("Basic Configuration")]
    public KeyCode[] myInputs;
    public GameObject mainCamera;
    public Image background;
    private bool doTransition;
    private bool lerpEnded;
    private bool normalize;

    [Header("Audio")]
    public AudioClip confirmation;

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
            SceneManager.LoadScene("Main Menu");
        }

        if (Input.GetKeyDown(myInputs[1]))
        {
            doTransition = true;
        }

        if (doTransition)
        {
            if (!normalize)
            {
                adsr.PlayOneShot(confirmation);
                normalize = true;
            }

            StartCoroutine(Transition(0.7f));

            if (!lerpEnded)
            {
                background.color = Color.Lerp(background.color, Color.black, 0.05f);
            }
            else
            {
                SceneManager.LoadScene(GameManager.currentLevel);
            }
        }
    }

    IEnumerator Transition(float time)
    {
        yield return new WaitForSeconds(time);

        lerpEnded = true;
    }
}
