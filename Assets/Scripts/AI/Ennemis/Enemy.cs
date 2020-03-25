using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [HideInInspector]
    public Animator amtr;
    [HideInInspector]
    public Rigidbody rgbd;
    [HideInInspector]
    public AudioSource adsr;
    private GameObject fire;

    [Header("Basic Configuration")]
    public float health = 1;
    public float damages = 1;
    public float speed = 1;
    public float healingDelay = 0;
    public bool flying;

    [Header("Audio")]
    public AudioClip attack;
    public AudioClip parry;

    private void Awake()
    {
        rgbd = GetComponent<Rigidbody>();
        amtr = GetComponent<Animator>();
        adsr = GetComponent<AudioSource>();
        fire = transform.Find("Fire").gameObject;

        amtr.SetBool("Dead", false);
        amtr.SetFloat("Speed", 1);
        fire.SetActive(false);

        rgbd.velocity += new Vector3(0, 0, 1) * speed;
    }

    private void Update()
    {
        healingDelay += Time.deltaTime * 1;
        if (healingDelay >= 2)
        {
            healingDelay = 0;
        }

        if (health <= 0)
        {
            Death();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Castle>() != null)
        {
            amtr.Play("attack_02");

            if (GameManager.soundOn)
            {
                adsr.PlayOneShot(attack);
            }

            other.GetComponent<Castle>().health -= damages;
            Destroy(gameObject, 0.5f);
        }

        if (other.GetComponent<Lava>() != null)
        {
            fire.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<P_Heal>() != null & healingDelay > 1.9f & healingDelay < 1.91111f)
        {
            health += 1f;
        }
    }

    private void Death()
    {
        amtr.SetBool("Dead", true);
        rgbd.velocity = new Vector3(0, rgbd.velocity.y, 0);

        if (flying)
        {
            rgbd.useGravity = true;
        }

        Destroy(gameObject, 2f);
    }
}