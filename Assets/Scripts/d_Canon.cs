using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class d_Canon : MonoBehaviour
{
    private GameObject enemyTarget;

    [Header("Basic Configuration")]
    public GameObject bullet;
    private GameObject shootingPlace;
    public float shootingCooldown = 1;
    private float timer;

    private void Start()
    {
        timer = shootingCooldown;
        shootingPlace = transform.Find("ShootingPlace").gameObject;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (GetComponent<Defense>().enemiesToKill.Count >= 1)
        {
            enemyTarget = GetComponent<Defense>().enemiesToKill[0];
            shootingPlace.transform.LookAt(enemyTarget.transform);
        }

        if (timer <= 0)
        {
            Instantiate(bullet, shootingPlace.transform.position, shootingPlace.transform.rotation);

            timer = shootingCooldown;
        }
    }
}
