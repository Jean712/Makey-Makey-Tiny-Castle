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
    public float shootingAngle;
    public Transform target;
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
        if (GetComponent<Defense>().active && GetComponent<Defense>().walkingEnemyToKill != null)
        {
            enemyTarget = GetComponent<Defense>().walkingEnemyToKill;

            if (enemyTarget != null)
            {
                d_CatapultDistance = enemyTarget.transform.position.z - target.position.z;
            }

            target.transform.LookAt(enemyTarget.transform.Find("ShootingTarget").transform);
            shootingPlace.transform.rotation = Quaternion.Euler(new Vector3(shootingAngle, target.rotation.eulerAngles.y, 0));

            if (timer <= 0)
            {
                amtr.Play("Attack");
                GetComponent<Defense>().adsr.PlayOneShot(GetComponent<Defense>().shoot);

                GameObject boulder = Instantiate(bullet, shootingPlace.transform.position, shootingPlace.transform.rotation);
                boulder.GetComponent<B_Boulder>().shootingPlaceAngle = shootingAngle;
                GetComponent<Defense>().heat += heatingSpeed;

                timer = shootingCooldown;
            }
        }
    }
}
