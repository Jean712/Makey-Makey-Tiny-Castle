using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class b_Cannonball : MonoBehaviour
{
    private Rigidbody rgbd;
    public float bulletSpeed = 100;

    void Start()
    {
        rgbd = GetComponent<Rigidbody>();

        rgbd.AddForce(Vector3.forward * bulletSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
