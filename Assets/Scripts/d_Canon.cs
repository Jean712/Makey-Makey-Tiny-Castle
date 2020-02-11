using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_Canon : MonoBehaviour
{
    private GameObject enemyTarget;

    [Header("Basic Configuration")]
    public GameObject bullet;
    private GameObject shootingPlace;
    public float shootingCooldown = 1;
    private float timer;

    private void Awake()
    {
        timer = shootingCooldown;
        shootingPlace = transform.Find("ShootingPlace").gameObject;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (GetComponent<Defense>().active && GetComponent<Defense>().enemyToKill != null)
        {
            enemyTarget = GetComponent<Defense>().enemyToKill;
            shootingPlace.transform.LookAt(enemyTarget.transform);

            if (timer <= 0)
            {
                Instantiate(bullet, shootingPlace.transform.position, shootingPlace.transform.rotation);

                timer = shootingCooldown;
            }
        }
    }
}
