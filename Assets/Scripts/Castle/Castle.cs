using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour
{
    public float health;

    private void Update()
    {
        if (health <= 0)
        {
            Debug.Log("Perdu");
        }
    }
}
