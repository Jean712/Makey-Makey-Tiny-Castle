using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public bool free = true;

    public GameObject[] defenses;
    public KeyCode[] inputs;

    void Start()
    {

    }

    void Update()
    {
        if (free)
        {
            if (Input.GetKeyDown(inputs[0]))
            {
                defenses[0].transform.position = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z);
            }
        }
    }
}
