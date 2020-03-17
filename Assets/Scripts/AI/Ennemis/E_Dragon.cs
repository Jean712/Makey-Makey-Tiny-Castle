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

    void Update()
    {
        //DragonAttack();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Enemy>().amtr.SetBool("Dead", true);
            Invoke("DeathAfterTime", 0.2f);
        }
    }

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
        /*if (fighting == true)
        {           
            rOF += 1 * Time.deltaTime;
        }
        if (rOF > 1.2f)
        {
            Instantiate(attackProjectile, pointSpawnProjectile.transform.position, pointSpawnProjectile.transform.rotation);
            rOF = 0;
        }*/
        Instantiate(attackProjectile, pointSpawnProjectile.transform.position, pointSpawnProjectile.transform.rotation);
    }

    public void DeathAfterTime()
    {
        GetComponent<Enemy>().rgbd.useGravity = true;
    }
}
