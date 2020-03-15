using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_Catapult : MonoBehaviour
{
    private GameObject enemyTarget;
    public static float d_CatapultDistance;

    [Header("Basic Configuration")]
    public GameObject bullet;
    public Animator amtr;
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
        if (GetComponent<Defense>().active && GetComponent<Defense>().walkingEnemyToKill != null)
        {
            enemyTarget = GetComponent<Defense>().walkingEnemyToKill;

            if (enemyTarget != null)
            {
                d_CatapultDistance = enemyTarget.transform.position.z - transform.position.z;
            }

            if (timer <= 0)
            {
                amtr.Play("Attack");

                Instantiate(bullet, shootingPlace.transform.position, shootingPlace.transform.rotation);
                GetComponent<Defense>().heat += heatingSpeed;

                timer = shootingCooldown;
            }
        }
    }
}
