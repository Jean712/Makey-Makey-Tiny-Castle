using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Mage : MonoBehaviour
{
    public float rOF = 0;

    public GameObject attackProjectile;
    public GameObject deathParticules;
    public GameObject pointSpawnProjectile;

    public bool fighting = false;

    private void Update()
    {
        MageAttack();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "tz_MageStopToMove")
        {
            fighting = true;
            GetComponent<Enemy>().rgbd.velocity = Vector3.zero;
            GetComponent<Enemy>().amtr.SetFloat("Speed", 0);
        }
    }

    // FONCTIONS

    private void MageAttack()
    {

        if (fighting == true)
        {
            //Debug.Log("jme tape");
            rOF += 1 * Time.deltaTime;
        }

        if (rOF > 2.4f)
        {
            //Debug.Log("Lavitesse d'attaque est à 1 dude");
            Instantiate(attackProjectile, pointSpawnProjectile.transform.position, pointSpawnProjectile.transform.rotation);
            rOF = 0;
        }
    }
}
