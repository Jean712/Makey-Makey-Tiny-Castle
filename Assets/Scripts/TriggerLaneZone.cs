using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLaneZone : MonoBehaviour
{
    public GameObject mySlot;
    public GameObject myDefense;

    private void OnTriggerEnter(Collider other)
    {
        GameObject enemy = other.gameObject;

        mySlot.GetComponent<Slot>().enemyQueue.Add(enemy);
    }
}
