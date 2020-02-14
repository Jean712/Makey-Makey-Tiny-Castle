using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_Catapult : MonoBehaviour
{
    private GameObject enemyTarget;

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
            shootingPlace.transform.LookAt(enemyTarget.transform);
            shootingPlace.transform.Rotate(-50, 0, 0);

            if (timer <= 0)
            {
                Instantiate(bullet, shootingPlace.transform.position, shootingPlace.transform.rotation);
                GetComponent<Defense>().heat += heatingSpeed;

                timer = shootingCooldown;
            }
        }
    }
}
