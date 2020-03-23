using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Dragon : MonoBehaviour
{
    public bool fighting;

    public GameObject attackProjectile;
    public GameObject deathParticules;
    public GameObject pointSpawnProjectile;

    public float rOF = 0;

    private void OnTriggerEnter(Collider LatriggerZone)
    {
        if(LatriggerZone.gameObject.name == "tz_DragonStopMove")
        {
            fighting = true;

            GetComponent<Enemy>().rgbd.velocity = Vector3.zero;

            GetComponent<Enemy>().amtr.SetFloat("Speed", 0);
            GetComponent<Enemy>().amtr.SetBool("Dead",false);
        }
    }

    public void DragonAttack()
    {
        GetComponent<Enemy>().adsr.PlayOneShot(GetComponent<Enemy>().attack);
        Instantiate(attackProjectile, pointSpawnProjectile.transform.position, pointSpawnProjectile.transform.rotation);
    }

    public void DeathAfterTime()
    {
        GetComponent<Enemy>().rgbd.useGravity = true;
    }
}
