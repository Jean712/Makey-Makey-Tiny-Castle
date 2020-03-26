using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [HideInInspector]
    public int round;

    [Header("Basic Configuration")]
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

    [Header("Round 4")]
    public Transform[] targets4;
    public GameObject[] enemies4;

    [Header("Round 5")]
    public Transform[] targets5;
    public GameObject[] enemies5;

    [Header("Round 6")]
    public Transform[] targets6;
    public GameObject[] enemies6;

    [Header("Round 7")]
    public Transform[] targets7;
    public GameObject[] enemies7;

    [Header("Round 8")]
    public Transform[] targets8;
    public GameObject[] enemies8;

    [Header("Round 9")]
    public Transform[] targets9;
    public GameObject[] enemies9;

    [Header("Round 10")]
    public Transform[] targets10;
    public GameObject[] enemies10;

    [Header("Round 11")]
    public Transform[] targets11;
    public GameObject[] enemies11;

    private void Awake()
    {
        round = 1;
        timer = 5;
    }

    private void Update()
    {
        if (!GameManager.isPaused)
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

                    case 4:
                        for (int i = 0; i < targets4.Length; i++)
                        {
                            Instantiate(enemies4[i], targets4[i]);
                        }

                        break;

                    case 5:
                        for (int i = 0; i < targets5.Length; i++)
                        {
                            Instantiate(enemies5[i], targets5[i]);
                        }

                        break;

                    case 6:
                        for (int i = 0; i < targets6.Length; i++)
                        {
                            Instantiate(enemies6[i], targets6[i]);
                        }

                        break;

                    case 7:
                        for (int i = 0; i < targets7.Length; i++)
                        {
                            Instantiate(enemies7[i], targets7[i]);
                        }

                        break;

                    case 8:
                        for (int i = 0; i < targets8.Length; i++)
                        {
                            Instantiate(enemies8[i], targets8[i]);
                        }

                        break;

                    case 9:
                        for (int i = 0; i < targets9.Length; i++)
                        {
                            Instantiate(enemies9[i], targets9[i]);
                        }

                        break;

                    case 10:
                        for (int i = 0; i < targets10.Length; i++)
                        {
                            Instantiate(enemies10[i], targets10[i]);
                        }

                        break;

                    case 11:
                        for (int i = 0; i < targets11.Length; i++)
                        {
                            Instantiate(enemies11[i], targets11[i]);
                        }

                        break;
                }

                round++;
                timer = roundCooldown;
            }
        }
    }
}
