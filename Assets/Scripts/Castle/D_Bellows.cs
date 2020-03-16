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
    public float tornadoSpeed;
    public GameObject tornado;
    public KeyCode myInput;
    public float baseSpeed;
    public float speedReduction;
    public float cooldown;
    private float timer;
    public float maxActivation;
    private float activation;

    [Header("Developer Only")]  // Developer Only //
    public bool infinite;       // Developer Only //

    private void Awake()
    {
        timer = cooldown;
        activation = maxActivation;
    }

    private void Update()
    {
        if (timer >= cooldown)
        {
            timer = cooldown;
        }

        // Ralentissement.
        if (Input.GetKeyDown(myInput) && !active)
        {
            activation = timer / cooldown * maxActivation;

            tornado.GetComponent<Rigidbody>().velocity += Vector3.forward * tornadoSpeed;

            if (actualEnemy != null)
            {
                actualEnemy.GetComponent<Enemy>().rgbd.velocity += Vector3.forward * speedReduction;
            }

            foreach (GameObject item in enemies)
            {
                item.GetComponent<Enemy>().rgbd.velocity += Vector3.forward * speedReduction;
            }

            active = true;
        }

        if (active)
        {
            activation -= Time.deltaTime;
        }
        else
        {
            timer += Time.deltaTime;
        }

        if (infinite)                                                                                       // Developer Only //
        {                                                                                                   // Developer Only //
            activation = maxActivation;                                                                     // Developer Only //

            if (Input.GetKeyUp(myInput))                                                                    // Developer Only //
            {                                                                                               // Developer Only //
                active = false;                                                                             // Developer Only //

                if (actualEnemy != null)                                                                    // Developer Only //
                {                                                                                           // Developer Only //
                    actualEnemy.GetComponent<Enemy>().rgbd.velocity -= Vector3.forward * speedReduction;    // Developer Only //
                }                                                                                           // Developer Only //

                foreach (GameObject item in enemies)                                                        // Developer Only //
                {                                                                                           // Developer Only //
                    item.GetComponent<Enemy>().rgbd.velocity -= Vector3.forward * speedReduction;           // Developer Only //
                }                                                                                           // Developer Only //
            }                                                                                               // Developer Only //
        }                                                                                                   // Developer Only //
        else                                                                                                // Developer Only //
        {                                                                                                   // Developer Only //
            if (activation <= 0)
            {
                if (actualEnemy != null)
                {
                    actualEnemy.GetComponent<Enemy>().rgbd.velocity -= Vector3.forward * speedReduction;
                }

                foreach (GameObject item in enemies)
                {
                    item.GetComponent<Enemy>().rgbd.velocity -= Vector3.forward * speedReduction;
                }

                timer = 0;

                tornado.GetComponent<Rigidbody>().velocity = Vector3.zero;
                tornado.transform.position = Vector3.zero;

                active = false;

                activation = maxActivation;
            }
        }                                                                   // Developer Only //
    }
}
