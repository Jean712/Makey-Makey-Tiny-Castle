using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private bool free = true;
    public bool isACooler = false;

    [Header("Basic Configuration")]
    public GameObject[] defenses;
    public Transform[] defensesLocation;
    public KeyCode[] myInputs;

    private void Update()
    {
        // Appartition de la défense.
        for (int i = 0; i < defenses.Length; i++)
        {
            if (Input.GetKeyDown(myInputs[i]) && free)
            {
                defenses[i].transform.position = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z);
                defenses[i].GetComponentInChildren<ParticleSystem>().Play();
            }

            if (Input.GetKey(myInputs[i]))
            {
                defenses[i].GetComponent<Defense>().active = true;
                free = false;

                // Refroidisseur.
                if (isACooler)
                {
                    defenses[i].GetComponent<Defense>().onCooler = true;
                }
            }

            if (Input.GetKeyUp(myInputs[i]))
            {
                defenses[i].GetComponent<Defense>().active = false;
                defenses[i].transform.position = defensesLocation[i].position;
                free = true;
            }
        }
    }
}
