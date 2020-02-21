using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float cooldown = 3;
    private float timer;

    public Transform target;
    public GameObject[] enemies;

    private void Awake()
    {
        timer = cooldown;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            int index = Random.Range(0, enemies.Length);

            if (enemies[index].GetComponent<Enemy>().flying)
            {
                Instantiate(enemies[index], target.transform.position + transform.forward * 2, transform.rotation);
            }
            else
            {
                Instantiate(enemies[index], transform.position + transform.forward * 2, transform.rotation);
            }

            timer = cooldown;
        }
    }
}
