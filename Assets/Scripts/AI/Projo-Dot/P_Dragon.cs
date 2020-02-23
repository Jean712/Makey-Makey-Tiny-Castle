using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Dragon : MonoBehaviour
{
    public Rigidbody rgbd;

    public float speed = 1;
    public float damages;

    private void Start()
    {
        rgbd = GetComponent<Rigidbody>();

        rgbd.velocity = new Vector3(0, 0, 1) * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Castle>() != null)
        {
            other.GetComponent<Castle>().health -= damages;

            Destroy(gameObject);
        }
    }
}
