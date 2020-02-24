using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_Bellows : MonoBehaviour
{
    [HideInInspector]
    public GameObject actualEnemy;
    [HideInInspector]
    public GameObject[] enemies;
    private bool active = false;

    [Header("Basic Configuration")]
    public KeyCode myInput;
    public float baseSpeed;
    public float speedReduction;
    public float maxCapacity;

    [Header("Developer Only")]  // Developer Only //
    public bool infinite;       // Developer Only //
    [Range(0, 45)]              // Developer Only //
    public float capacity;      // Developer Only //

    private void Awake()
    {
        capacity = maxCapacity;
    }

    private void Update()
    {
        if (capacity >= maxCapacity)
        {
            capacity = maxCapacity;
        }

        // Ralentissement.
        if (Input.GetKeyDown(myInput))
        {
            active = true;
        }

        if (active)
        {
            if (actualEnemy != null)
            {
                actualEnemy.GetComponent<Enemy>().speed = speedReduction;
            }

            foreach (GameObject item in enemies)
            {
                item.GetComponent<Enemy>().speed = speedReduction;
            }

            capacity -= Time.deltaTime;
        }
        else
        {
            capacity += Time.deltaTime;
        }

        if (infinite)                                                       // Developer Only //
        {                                                                   // Developer Only //
            capacity = maxCapacity;                                         // Developer Only //

            if (Input.GetKeyUp(myInput))                                    // Developer Only //
            {                                                               // Developer Only //
                active = false;                                             // Developer Only //

                if (actualEnemy != null)                                    // Developer Only //
                {                                                           // Developer Only //
                    actualEnemy.GetComponent<Enemy>().speed = baseSpeed;    // Developer Only //
                }                                                           // Developer Only //

                foreach (GameObject item in enemies)                        // Developer Only //
                {                                                           // Developer Only //
                    item.GetComponent<Enemy>().speed = baseSpeed;           // Developer Only //
                }                                                           // Developer Only //
            }                                                               // Developer Only //

        }                                                                   // Developer Only //
        else                                                                // Developer Only //
        {                                                                   // Developer Only //
            if (capacity <= 0)
            {
                active = false;

                actualEnemy.GetComponent<Enemy>().speed = baseSpeed;

                foreach (GameObject item in enemies)
                {
                    item.GetComponent<Enemy>().speed = baseSpeed;
                }
            }
        }                                                                   // Developer Only //
    }
}
