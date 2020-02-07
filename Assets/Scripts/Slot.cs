using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private bool free = true;
    public bool isACooler = false;

    public List<GameObject> enemyQueue;

    [Header("Basic Configuration")]
    public GameObject[] defenses;
    public Transform[] defensesLocation;
    public KeyCode[] myInputs;
    public GameObject myZone;

    private void Awake()
    {
        if (myZone != null)
        {
            myZone.GetComponent<TriggerLaneZone>().mySlot = gameObject;
        }
    }

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
                free = false;

                // Refroidisseur.
                if (isACooler)
                {
                    defenses[i].GetComponent<Defense>().onCooler = true;
                }
                else
                {
                    myZone.GetComponent<TriggerLaneZone>().myDefense = defenses[i];
                    defenses[i].GetComponent<Defense>().enemiesToKill = enemyQueue;
                    defenses[i].GetComponent<Defense>().active = true;
                }
            }

            if (Input.GetKeyUp(myInputs[i]))
            {
                myZone.GetComponent<TriggerLaneZone>().myDefense = null;
                defenses[i].GetComponent<Defense>().active = false;
                defenses[i].GetComponent<Defense>().onCooler = false;
                defenses[i].GetComponent<Defense>().enemiesToKill = null;
                defenses[i].transform.position = defensesLocation[i].position;
                free = true;
            }
        }
    }
}
