using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage_Projectile : MonoBehaviour
{
    public Rigidbody r_MageProjectile;

    public float _projectileSpeed = 10;



    void Start()
    {
        r_MageProjectile.velocity = new Vector3(0, 0, 10) * _projectileSpeed;
    }


    void Update()
    {
        Destroy(gameObject, 2);
    }
}
