using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_Magic : MonoBehaviour
{
    private AudioSource adsr;
    private Rigidbody rgbd;
    private ParticleSystem ptcl;

    [Header("Basic Configuration")]
    public GameObject explosionParticle;
    public float bulletSpeed;
    public float damages;
    public float blastRadius;
    private GameObject[] allEnemies;
    private bool asHit = false;

    [Header("Sound")]
    public AudioClip impact;

    private void Awake()
    {
        rgbd = GetComponent<Rigidbody>();
        adsr = GetComponent<AudioSource>();
        ptcl = GetComponentInChildren<ParticleSystem>();

        GetComponent<GizmoCreator>().gizmoSize = blastRadius;   // Developer Only //
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
                if (other.GetComponent<E_Mage>())
                {
                    other.gameObject.GetComponentInChildren<ParticleSystem>().Play();
                    other.GetComponent<Enemy>().adsr.PlayOneShot(other.GetComponent<Enemy>().parry);
                }
                else
                {
                    other.GetComponent<Enemy>().health -= damages;

                    AOE();
                }

                ptcl.Stop();
                Destroy(gameObject, 3);
            }

            asHit = true;
        }

        if (other.name == "Floor")
        {
            if (!asHit)
            {
                AOE();

                ptcl.Stop();
                Destroy(gameObject, 3);
            }

            asHit = true;
        }
    }

    private void AOE()
    {
        Instantiate(explosionParticle, transform.position, transform.rotation);
        adsr.PlayOneShot(impact);

        allEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject item in allEnemies)
        {
            if (blastRadius >= Vector3.Distance(transform.position, item.transform.position) && !item.GetComponent<E_Mage>())
            {
                item.GetComponent<Enemy>().health -= damages;
            }
        }
    }
}
