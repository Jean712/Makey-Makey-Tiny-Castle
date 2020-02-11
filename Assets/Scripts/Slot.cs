using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private bool free = true;

    public Queue<GameObject> enemyQueue;
    private GameObject actualEnemy;

    [Header("Basic Configuration")]
    public GameObject[] defenses;
    public KeyCode[] myInputs;
    public GameObject myZone;
    public bool isACooler = false;

    private void Awake()
    {
        if (myZone != null)
        {
            enemyQueue = new Queue<GameObject>();
            myZone.GetComponent<TriggerLaneZone>().mySlot = gameObject;
        }
    }

    private void Update()
    {
        if (actualEnemy == null && enemyQueue.Count >= 1)
        {
            actualEnemy = enemyQueue.Dequeue();
        }

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
                defenses[i].GetComponent<Defense>().onSlot = true;

                // Refroidisseur.
                if (isACooler)
                {
                    defenses[i].GetComponent<Defense>().onCooler = true;
                }
                else
                {
                    myZone.GetComponent<TriggerLaneZone>().myDefense = defenses[i];
                    defenses[i].GetComponent<Defense>().enemyToKill = actualEnemy;
                }
            }

            if (Input.GetKeyUp(myInputs[i]))
            {
                myZone.GetComponent<TriggerLaneZone>().myDefense = null;
                defenses[i].GetComponent<Defense>().onSlot = false;
                defenses[i].GetComponent<Defense>().onCooler = false;
                defenses[i].GetComponent<Defense>().enemyToKill = null;
                defenses[i].transform.position = defenses[i].GetComponent<Defense>().myLocation.position;
                free = true;
            }
        }
    }
}
