using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_Boulder : MonoBehaviour
{
    private Rigidbody rgbd;
    public float damages;
    private float initialForce;
    public float initialBoost;

    private void Awake()
    {
        rgbd = GetComponent<Rigidbody>();

        initialForce = Mathf.Sqrt(D_Catapult.d_CatapultDistance * Physics.gravity.magnitude) * initialBoost;
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
