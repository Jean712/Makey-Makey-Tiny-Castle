using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    [HideInInspector]
    public float damages;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>() == true)
        {
            other.GetComponent<Enemy>().health -= damages;
        }
    }
}
