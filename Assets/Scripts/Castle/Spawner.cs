using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Basic Configuration")]
    private int round;
    public float roundCooldown = 3;
    private float timer;

    [Header("Round 1")]
    public Transform[] targets1;
    public GameObject[] enemies1;

    [Header("Round 2")]
    public Transform[] targets2;
    public GameObject[] enemies2;

    [Header("Round 3")]
    public Transform[] targets3;
    public GameObject[] enemies3;

    private void Awake()
    {
        round = 1;
        timer = roundCooldown;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            switch (round)
            {
                case 1:
                    for (int i = 0; i < targets1.Length; i++)
                    {
                        Instantiate(enemies1[i], targets1[i]);
                    }

                    break;

                case 2:
                    for (int i = 0; i < targets2.Length; i++)
                    {
                        Instantiate(enemies2[i], targets2[i]);
                    }

                    break;

                case 3:
                    for (int i = 0; i < targets3.Length; i++)
                    {
                        Instantiate(enemies3[i], targets3[i]);
                    }

                    break;
            }

            round++;
            timer = roundCooldown;
        }
    }
}
