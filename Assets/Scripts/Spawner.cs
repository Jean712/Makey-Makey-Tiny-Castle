using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float cooldown = 5;
    private float timer;

    public GameObject[] enemies;

    void Start()
    {
        timer = cooldown;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Instantiate(enemies[Random.Range(0, enemies.Length)], new Vector3(transform.position.x, transform.position.y, transform.position.z - 1), Quaternion.identity);
            timer = cooldown;
        }
    }
}
