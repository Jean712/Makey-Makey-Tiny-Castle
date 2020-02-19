using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defense : MonoBehaviour
{
    public bool onSlot;
    public bool active = false;
    public GameObject enemyToKill;
    public bool canHeat = false;
    private bool overheated = false;

    [Header("Basic Configuration")]
    public float timeBeforeShooting = 1;
    private float timer1;
    public Transform myLocation;
    public KeyCode[] myInputs;

    [Header("Statistics")]
    [Range(0, 100)]
    public float heat;
    public float coolingSpeed = 1;
    public float coolingSpeedOnBooster = 2;
    public float overheatedCancelTime;
    private float timer2;
    public bool onCooler;

    private void Awake()
    {
        timer1 = timeBeforeShooting;
        timer2 = overheatedCancelTime;
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
        if (canHeat)
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

                if (heat >= 100)
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
                        heat = 0;
                        overheated = false;
                    }
                }
            }
        }
    }
}
