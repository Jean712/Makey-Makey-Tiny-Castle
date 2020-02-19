using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_ProjectileMage : MonoBehaviour
{
    public Rigidbody r_MageProjectile;

    public float _projectileSpeed = 10;
    public float f_damages;




    void Start()
    {
        r_MageProjectile.velocity = new Vector3(0, 0, 10) * _projectileSpeed;
    }


    void Update()
    {
        
 
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Castle>() != null)
        {
            other.GetComponent<Castle>().health -= f_damages;
            Destroy(gameObject);
        }
    }

}
