using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float cooldown = 5;
    private float timer;

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
                Instantiate(enemies[index], new Vector3(transform.position.x, transform.position.y + 3, transform.position.z - 1), Quaternion.identity);
            }
            else
            {
                Instantiate(enemies[index], new Vector3(transform.position.x, transform.position.y, transform.position.z - 1), Quaternion.identity);
            }

            timer = cooldown;
        }
    }
}
