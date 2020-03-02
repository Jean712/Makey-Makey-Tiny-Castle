using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Defense : MonoBehaviour
{
    [HideInInspector]
    public bool onSlot;
    [HideInInspector]
    public bool onCooler;
    [HideInInspector]
    public bool active = false;
    [HideInInspector]
    public GameObject enemyToKill;
    [HideInInspector]
    public GameObject walkingEnemyToKill;
    [HideInInspector]
    public GameObject flyingEnemyToKill;

    [Header("Developer Only")]          // Developer Only //
    public bool canHeat = false;        // Developer Only //
    [Range(0, 100)]                     // Developer Only //
    public float heat;                  // Developer Only //
    public bool overheated = false;     // Developer Only //

    [Header("Basic Configuration")]
    public float timeBeforeShooting = 1;
    private float timer1;
    public Transform myLocation;
    public KeyCode[] myInputs;
    public float maxHeat;
    public GameObject cooldownBar;
    public float coolingSpeed = 1;
    public float coolingSpeedOnBooster = 2;
    public float heatAfterCancel;
    public float overheatedCancelTime;
    private float timer2;

    private void Awake()
    {
        timer1 = timeBeforeShooting;
        timer2 = overheatedCancelTime;

        cooldownBar.GetComponent<Slider>().maxValue = maxHeat;
    }

    private void Update()
    {
        // Activation et désactivation.
        for (int i = 0; i < myInputs.Length; i++)
        {
            if (onSlot && !overheated)
            {
                if (Input.GetKey(myInputs[i]))
                {
                    timer1 -= Time.deltaTime;

                    if (timer1 <= 0)
                    {
                        active = true;
                    }
                }
            }

            if (Input.GetKeyUp(myInputs[i]))
            {
                active = false;
                timer1 = timeBeforeShooting;
            }
        }

        //Surchauffe et refroidissement.
        if (canHeat)                                                    // Developer Only //
        {
            if (timer2 == overheatedCancelTime)
            {
                if (!active)
                {
                    heat -= coolingSpeed * Time.deltaTime;
                }

                if (onCooler)
                {
                    heat -= coolingSpeedOnBooster * Time.deltaTime;
                }

                if (heat < 0)
                {
                    heat = 0;
                }

                if (heat >= maxHeat)
                {
                    overheated = true;
                }
            }

            // Récupération.
            if (!overheated)
            {
                timer2 = overheatedCancelTime;
            }

            if (overheated)
            {
                active = false;

                if (!onSlot)
                {
                    timer2 -= Time.deltaTime;

                    if (timer2 <= 0)
                    {
                        heat = heatAfterCancel;
                        overheated = false;
                    }
                }
            }
        }                                                               //Developer Only //

        cooldownBar.GetComponent<Slider>().value = heat;
    }
}
