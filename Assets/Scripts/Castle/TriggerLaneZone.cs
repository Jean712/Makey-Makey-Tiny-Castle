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
            mySlot.GetComponent<Slot>().enemiesQueue.Enqueue(other.gameObject);
            
            if (other.GetComponent<Enemy>().flying)
            {
                mySlot.GetComponent<Slot>().flyingEnemiesQueue.Enqueue(other.gameObject);
            }
            else
            {
                mySlot.GetComponent<Slot>().walkingEnemiesQueue.Enqueue(other.gameObject);
            }
        }
    }
}
