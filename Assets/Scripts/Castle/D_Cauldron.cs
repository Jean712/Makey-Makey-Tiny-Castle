using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_Cauldron : MonoBehaviour
{
    private AudioSource adsr;

    [Header("Basic Configuration")]
    public GameObject lava;
    public GameObject lavaLevel;
    public Animator amtr;
    public KeyCode myInput;
    private bool active;
    public float distance = 1;
    public float maxDamages;
    private float damages;
    public float cooldown;
    private float timer;

    [Header("Audio")]
    public AudioClip activation;

    private void Awake()
    {
        adsr = GetComponent<AudioSource>();

        timer = cooldown;

        transform.Find("Target").GetComponent<GizmoCreator>().gizmoSize = distance;    // Developer Only //
    }

    private void Update()
    {
        if (!GameManager.isPaused)
        {
            timer += Time.deltaTime;

            if (timer >= cooldown)
            {
                timer = cooldown;
            }

            if (Input.GetKeyDown(myInput) && !active)
            {
                amtr.Play("Attack");

                if (GameManager.soundOn)
                {
                    adsr.PlayOneShot(activation);
                }

                active = true;
                damages = timer / cooldown * maxDamages;
                lava.GetComponent<Lava>().damages = damages;

                lavaLevel.SetActive(false);
            }

            if (active)
            {
                lava.transform.position = Vector3.Lerp(lava.transform.position, new Vector3(-1.5f, 0, 41 - distance), 0.05f);

                StartCoroutine(LavaMovement(3));
            }
            else
            {
                lavaLevel.transform.position = new Vector3(-1.5f, timer / cooldown + 5, 38.5f);
            }
        }
    }

    IEnumerator LavaMovement(float time)
    {
        yield return new WaitForSeconds(time);

        lava.transform.position = Vector3.Lerp(lava.transform.position, lava.transform.position + Vector3.down / 4, 0.05f);

        active = false;

        yield return new WaitForSeconds(time);

        lava.transform.position = new Vector3(-1.5f, 0, 41);
        lavaLevel.SetActive(true);
        timer = 0;
    }
}
