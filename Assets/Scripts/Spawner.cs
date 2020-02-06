using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] defenses;
    //private GameObject[] instDefenses = new GameObject[4];
    public Transform[] defensesLocation;

    public KeyCode[] myInputs;

    private bool free;

    //void Update()
    //{
    //    for (int i = 0; i < defenses.Length; i++)
    //    {
    //        if (Input.GetKeyDown(myInputs[i]) && free)
    //        {
    //            instDefenses[i] = Instantiate(defenses[i], new Vector3(transform.position.x, transform.position.y + 5, transform.position.z), transform.rotation);
    //        }

    //        if (Input.GetKeyUp(myInputs[i]))
    //        {
    //            Destroy(instDefenses[i]);
    //            free = true;
    //        }

    //        if (Input.GetKey(myInputs[i]))
    //        {
    //            free = false;
    //        }
    //    }
    //}

    void Update()
    {
        for (int i = 0; i < defenses.Length; i++)
        {
            if (Input.GetKeyDown(myInputs[i]) && free)
            {
                defenses[i].transform.position = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z);
            }

            if (Input.GetKeyUp(myInputs[i]))
            {
                defenses[i].transform.position = defensesLocation[i].position;
                free = true;
            }

            if (Input.GetKey(myInputs[i]))
            {
                free = false;
            }
        }
    }
}
