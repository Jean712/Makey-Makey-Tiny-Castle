using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Mage : MonoBehaviour
{
    public Rigidbody rgbd;

    public float speed = 10;
    public float damages;

    private void Start()
    {
        rgbd = GetComponent<Rigidbody>();

        rgbd.velocity = new Vector3(0, 0, 10) * speed;
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
