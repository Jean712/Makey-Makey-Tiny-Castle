using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_Magic : MonoBehaviour
{
    private Rigidbody rgbd;

    [Header("Basic Configuration")]
    public GameObject explosionParticle;
    public float bulletSpeed;
    public float damages;
    public float blastRadius;
    private GameObject[] allEnemies;

    private void Awake()
    {
        rgbd = GetComponent<Rigidbody>();

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
            if (other.GetComponent<E_Mage>())
            {
                other.gameObject.GetComponentInChildren<ParticleSystem>().Play();
            }
            else
            {
                other.GetComponent<Enemy>().health -= damages;
            }

            AOE();

            Destroy(gameObject);
        }

        if (other.name == "Floor")
        {
            AOE();

            Destroy(gameObject);
        }
    }

    private void AOE()
    {   
        Instantiate(explosionParticle, transform.position, transform.rotation);

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
