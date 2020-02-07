using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defense : MonoBehaviour
{
    public KeyCode[] myInputs;

    public bool active;

    public float heat;
    public float coolingSpeed = 1;
    public float coolingSpeedOnBooster = 2;
    public bool onCooler;

    void Update()
    {
        // Surchauffe.
        if (active)
        {
            
        }

        // Refroidissement.
        if (!active)
        {
            heat -= coolingSpeed;
        }

        if (onCooler)
        {
            heat -= coolingSpeedOnBooster;
        }

        heat = Mathf.Clamp(heat, 0, 100);
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
