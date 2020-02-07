using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defense : MonoBehaviour
{
    public bool active;
    public List<GameObject> enemiesToKill;

    //[Header("Basic Configuration")]
    //public Component myWeaponScript;
    public KeyCode[] myInputs;

    [Header("Statistics")]
    public float heat = 100;
    public float coolingSpeed = 1;
    public float coolingSpeedOnBooster = 2;
    public bool onCooler;

    void Update()
    {
        // Visée.
        if (active)
        {

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
