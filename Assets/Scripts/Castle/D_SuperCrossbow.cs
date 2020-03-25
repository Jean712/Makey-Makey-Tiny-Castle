using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_SuperCrossbow : MonoBehaviour
{
    private GameObject enemyTarget;

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
        shootingCooldown = minShootingCooldown;
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
            enemyTarget = GetComponent<Defense>().enemyToKill;
            shootingPlace.transform.LookAt(enemyTarget.transform.Find("ShootingTarget").transform);

            if (timer <= 0)
            {
                amtr.Play("Attack");
                GetComponent<Defense>().adsr.PlayOneShot(GetComponent<Defense>().shoot);

                Instantiate(bullet, shootingPlace.transform.position, shootingPlace.transform.rotation);
                GetComponent<Defense>().heat += heatingSpeed;

                timer = shootingCooldown;
            }
        }
    }
}
