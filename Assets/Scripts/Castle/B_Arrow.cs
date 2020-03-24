using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_Arrow : MonoBehaviour
{
    private Rigidbody rgbd;
    private AudioSource adsr;
    private MeshRenderer mshr;

    [Header("Basic Configuration")]
    public float bulletSpeed;
    public float damages;
    private bool asHit = false;

    [Header("Sound")]
    public AudioClip impact;

    private void Awake()
    {
        rgbd = GetComponent<Rigidbody>();
        adsr = GetComponent<AudioSource>();
        mshr = GetComponentInChildren<MeshRenderer>();
    }

    private void Update()
    {
        rgbd.velocity = gameObject.transform.forward * bulletSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>() != null)
        {
            if (!asHit)
            {
                if (other.GetComponent<E_Shield>())
                {
                    other.gameObject.GetComponentInChildren<ParticleSystem>().Play();
                    other.GetComponent<Enemy>().adsr.PlayOneShot(other.GetComponent<Enemy>().parry);
                }
                else
                {
                    adsr.PlayOneShot(impact);

                    other.GetComponent<Enemy>().health -= damages;
                }

                mshr.enabled = false;
                Destroy(gameObject, 3);
            }

            asHit = true;
        }
    }
}
