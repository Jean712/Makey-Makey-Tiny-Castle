using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_Canon : MonoBehaviour
{
    public GameObject enemyTarget;

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
        if (GetComponent<Defense>().active && GetComponent<Defense>().walkingEnemyToKill != null)
        {
            enemyTarget = GetComponent<Defense>().walkingEnemyToKill;
            shootingPlace.transform.LookAt(enemyTarget.transform.Find("ShootingTarget").transform);

            if (timer <= 0)
            {
                Instantiate(bullet, shootingPlace.transform.position, shootingPlace.transform.rotation);
                GetComponent<Defense>().heat += heatingSpeed;

                timer = shootingCooldown;
            }
        }
    }
}
