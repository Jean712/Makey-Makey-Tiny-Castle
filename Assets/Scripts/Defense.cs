using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defense : MonoBehaviour
{
    public bool onSlot;
    public bool active = false;
    public GameObject enemyToKill;

    [Header("Basic Configuration")]
    public float timeBeforeShooting = 1f;
    private float timer;
    public Transform myLocation;
    public KeyCode[] myInputs;

    [Header("Statistics")]
    public float heat = 100;
    public float coolingSpeed = 1;
    public float coolingSpeedOnBooster = 2;
    public bool onCooler;

    private void Awake()
    {
        timer = timeBeforeShooting;
    }

    private void Update()
    {
        // Activation et désactivation.
        for (int i = 0; i < myInputs.Length; i++)
        {
            if (onSlot)
            {
                if (Input.GetKey(myInputs[i]))
                {
                    timer -= Time.deltaTime;

                    if (timer <= 0)
                    {
                        active = true;
                    }
                }
            }

            if (Input.GetKeyUp(myInputs[i]))
            {
                active = false;
                timer = timeBeforeShooting;
            }
        }

        // Refroidissement.
        if (!active)
        {
            heat -= coolingSpeed * Time.deltaTime;
        }

        if (onCooler)
        {
            heat -= coolingSpeedOnBooster * Time.deltaTime;
        }

        heat = Mathf.Clamp(heat, 0, 100);
    }
}
