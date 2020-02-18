using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_Catapult : MonoBehaviour
{
    private GameObject enemyTarget;
    public static float d_CatapultDistance;

    [Header("Basic Configuration")]
    public GameObject bullet;
    private GameObject shootingPlace;
    public float shootingCooldown;
    public float heatingSpeed;
    private float timer;

    private void Awake()
    {
        timer = shootingCooldown;
        shootingPlace = transform.Find("ShootingPlace").gameObject;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        
        // Tir.
        if (GetComponent<Defense>().active && GetComponent<Defense>().enemyToKill != null)
        {
            enemyTarget = GetComponent<Defense>().enemyToKill;

            if (timer <= 0)
            {
                Instantiate(bullet, shootingPlace.transform.position, shootingPlace.transform.rotation);
                GetComponent<Defense>().heat += heatingSpeed;

                timer = shootingCooldown;
            }
        }

        if (enemyTarget != null)
        {
            d_CatapultDistance = enemyTarget.transform.position.z - transform.position.z;
        }

        Debug.Log(d_CatapultDistance);
    }
}
