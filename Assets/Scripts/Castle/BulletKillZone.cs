using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletKillZone : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
        }
    }
}
