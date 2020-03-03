using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Mage : MonoBehaviour
{
    public GameObject attackProjectile;
    public GameObject deathParticules;
    public GameObject pointSpawnProjectile;

    public bool fighting = false;
   
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "tz_MageStopToMove")
        {
            fighting = true;
            GetComponent<Enemy>().rgbd.velocity = Vector3.zero;

            GetComponent<Enemy>().amtr.SetFloat("Speed", 0);
            GetComponent<Enemy>().amtr.SetBool("Dead", false);
        }
    }

    // FONCTIONS

    private void MageAttack()
    {
        Instantiate(attackProjectile, pointSpawnProjectile.transform.position, pointSpawnProjectile.transform.rotation);
    }
}
