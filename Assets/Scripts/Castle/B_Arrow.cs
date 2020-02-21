using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_Arrow : MonoBehaviour
{
    private Rigidbody rgbd;
    public float bulletSpeed;

    public float damages;

    private void Awake()
    {
        rgbd = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rgbd.velocity = gameObject.transform.forward * bulletSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>() != null)
        {
            if (other.GetComponent<E_Shield>())
            {
                //other.gameObject.GetComponentInChildren<ParticleSystem>().Play();
            }
            else
            {
                other.GetComponent<Enemy>().health -= damages;
            }

            Destroy(gameObject);
        }
    }
}
