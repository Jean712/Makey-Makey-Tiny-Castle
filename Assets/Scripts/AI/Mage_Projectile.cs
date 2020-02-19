using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage_Projectile : MonoBehaviour
{
    public Rigidbody r_MageProjectile;

    public float _projectileSpeed = 10;
    public float damages = 1;



    void Start()
    {
        r_MageProjectile.velocity = new Vector3(0, 0, 10) * _projectileSpeed;
    }


    void Update()
    {
        Destroy(gameObject, 2);
    }


    private void OnTriggerEnter(Collider other)
    {
        //if (other.GetComponent<Castle>() != null)
        //{
        //    other.GetComponent<Castle>().health -= damages;
        //    Destroy(gameObject);
        //}
        
    }
}
