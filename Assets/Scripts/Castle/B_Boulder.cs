using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_Boulder : MonoBehaviour
{
    private Rigidbody rgbd;
    private AudioSource adsr;
    private MeshRenderer mshr;

    [Header("Basic Configuration")]
    public GameObject explosionParticle;
    private float initialForce;
    public float initialBoost;
    [Range(0, -90)]
    public float shootingPlaceAngle;
    public float damages;
    public float blastRadius;
    private GameObject[] allEnemies;
    private bool asHit = false;

    [Header("Sound")]
    public AudioClip impact;
    public AudioClip flying;

    private void Awake()
    {
        GetComponent<GizmoCreator>().gizmoSize = blastRadius;   // Developer Only //

        rgbd = GetComponent<Rigidbody>();
        adsr = GetComponent<AudioSource>();
        mshr = GetComponentInChildren<MeshRenderer>();

        initialForce = Mathf.Sqrt((-D_Catapult.d_CatapultDistance / Mathf.Sin(2 * shootingPlaceAngle)) * Physics.gravity.magnitude) * initialBoost;
        rgbd.AddForce(transform.forward * initialForce, ForceMode.Impulse);

        adsr.PlayOneShot(flying);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!asHit)
        {
            adsr.PlayOneShot(impact);

            if (other.GetComponent<Enemy>() != null)
            {
                if (!other.GetComponent<E_Dragon>())
                {
                    other.GetComponent<Enemy>().health -= damages;
                }

                AOE();

                mshr.enabled = false;
                Destroy(gameObject, 3);
            }

            if (other.name == "Floor")
            {
                AOE();

                mshr.enabled = false;
                Destroy(gameObject, 3);
            }
        }

        asHit = true;
    }

    private void AOE()
    {
        Instantiate(explosionParticle, transform.position, transform.rotation);

        allEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject item in allEnemies)
        {
            if (blastRadius >= Vector3.Distance(transform.position, item.transform.position) && !item.GetComponent<E_Dragon>())
            {
                item.GetComponent<Enemy>().health -= damages;
            }
        }
    }
}
