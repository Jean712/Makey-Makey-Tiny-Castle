using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_Boulder : MonoBehaviour
{
    private Rigidbody rgbd;
    private AudioSource adsr;
    private MeshRenderer mshr;
    [HideInInspector]
    public float shootingPlaceAngle;

    [Header("Basic Configuration")]
    public GameObject explosionParticle;
    private float initialForce;
    public float initialBoost;
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
        if (other.GetComponent<Enemy>() != null)
        {
            if (!asHit)
            {
                if (!other.GetComponent<E_Dragon>())
                {
                    other.GetComponent<Enemy>().health -= damages;
                }

                AOE();

                mshr.enabled = false;
                Destroy(gameObject, 3);
            }

            asHit = true;
        }

        if (other.name == "Floor")
        {
            if (!asHit)
            {
                AOE();

                mshr.enabled = false;
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
            if (blastRadius >= Vector3.Distance(transform.position, item.transform.position) && !item.GetComponent<E_Dragon>())
            {
                item.GetComponent<Enemy>().health -= damages;
            }
        }
    }
}
