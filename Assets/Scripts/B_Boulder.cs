using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_Boulder : MonoBehaviour
{
    private Rigidbody rgbd;
    public float damages;
    public float initialForce = 75;

    private void Awake()
    {
        rgbd = GetComponent<Rigidbody>();

        rgbd.AddForce(transform.forward * initialForce);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>() != null)
        {
            other.GetComponent<Enemy>().health -= damages;
            Destroy(gameObject);
        }
    }
}
