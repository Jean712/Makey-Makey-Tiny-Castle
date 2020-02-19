using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLaneZone : MonoBehaviour
{
    public GameObject mySlot;
    public GameObject myDefense;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            GameObject enemy = other.gameObject;

            mySlot.GetComponent<Slot>().enemiesQueue.Enqueue(enemy);
            
            if (other.GetComponent<Enemy>().flying)
            {
                mySlot.GetComponent<Slot>().flyingEnemiesQueue.Enqueue(enemy);
            }
            else
            {
                mySlot.GetComponent<Slot>().walkingEnemiesQueue.Enqueue(enemy);
            }
        }
    }
}
