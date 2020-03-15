using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_MageTower : MonoBehaviour
{
    private GameObject enemyTarget;

    [Header("Basic Configuration")]
    public GameObject bullet;
    private GameObject shootingPlace;
    public float minShootingCooldown;
    private float shootingCooldown;
    public float maxShootingCooldown;
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

        // Manivelle.
        if (GetComponent<Defense>().crankActive)
        {
            shootingCooldown = Mathf.Lerp(shootingCooldown, maxShootingCooldown, 0.07f);
        }
        else
        {
            shootingCooldown = minShootingCooldown;
        }

        // Tir.
        if (GetComponent<Defense>().active && GetComponent<Defense>().enemyToKill != null)
        {
            if (GetComponent<Defense>().flyingEnemyToKill != null)
            {
                enemyTarget = GetComponent<Defense>().flyingEnemyToKill;
            }
            else
            {
                enemyTarget = GetComponent<Defense>().enemyToKill;
            }

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
