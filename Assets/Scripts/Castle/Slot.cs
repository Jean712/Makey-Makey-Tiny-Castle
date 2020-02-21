using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private bool free = true;

    [HideInInspector]
    public Queue<GameObject> enemiesQueue;
    [HideInInspector]
    public Queue<GameObject> walkingEnemiesQueue;
    [HideInInspector]
    public Queue<GameObject> flyingEnemiesQueue;
    public GameObject actualEnemy;
    public GameObject actualWalkingEnemy;
    public GameObject actualFlyingEnemy;

    [Header("Basic Configuration")]
    public Transform target;
    public GameObject[] defenses;
    public KeyCode[] myInputs;
    public GameObject myZone;
    public bool isACooler = false;

    private void Awake()
    {
        if (myZone != null)
        {
            enemiesQueue = new Queue<GameObject>();
            walkingEnemiesQueue = new Queue<GameObject>();
            flyingEnemiesQueue = new Queue<GameObject>();

            myZone.GetComponent<TriggerLaneZone>().mySlot = gameObject;
        }
    }

    private void Update()
    {
        if (enemiesQueue.Count >= 1)
        {
            if (actualEnemy != null)
            {
                if (actualEnemy.GetComponent<Enemy>().health <= 0)
                {
                    actualEnemy = enemiesQueue.Dequeue();
                }
            }
            else
            {
                actualEnemy = enemiesQueue.Dequeue();
            }
        }

        if (walkingEnemiesQueue.Count >= 1)
        {
            if (actualWalkingEnemy != null)
            {
                if (actualWalkingEnemy.GetComponent<Enemy>().health <= 0)
                {
                    actualWalkingEnemy = walkingEnemiesQueue.Dequeue();
                }
            }
            else
            {
                actualWalkingEnemy = walkingEnemiesQueue.Dequeue();
            }
        }

        if (flyingEnemiesQueue.Count >= 1)
        {
            if (actualFlyingEnemy != null)
            {
                if (actualFlyingEnemy.GetComponent<Enemy>().health <= 0)
                {         
                    actualFlyingEnemy = flyingEnemiesQueue.Dequeue();
                }
            }
            else
            {
                actualFlyingEnemy = flyingEnemiesQueue.Dequeue();
            }
        }

        //if (actualEnemy == null && enemiesQueue.Count >= 1)
        //{
        //    actualEnemy = enemiesQueue.Dequeue();
        //}

        //if (actualWalkingEnemy == null && walkingEnemiesQueue.Count >= 1)
        //{
        //    actualWalkingEnemy = walkingEnemiesQueue.Dequeue();
        //}

        //if (actualFlyingEnemy == null && flyingEnemiesQueue.Count >= 1)
        //{
        //    actualFlyingEnemy = flyingEnemiesQueue.Dequeue();
        //}

        // Appartition de la défense.
        for (int i = 0; i < defenses.Length; i++)
        {
            if (Input.GetKeyDown(myInputs[i]) && free)
            {
                defenses[i].transform.position = target.position;
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
                    defenses[i].GetComponent<Defense>().walkingEnemyToKill = actualWalkingEnemy;
                    defenses[i].GetComponent<Defense>().flyingEnemyToKill = actualFlyingEnemy;
                }
            }

            if (Input.GetKeyUp(myInputs[i]))
            {
                myZone.GetComponent<TriggerLaneZone>().myDefense = null;
                defenses[i].GetComponent<Defense>().onSlot = false;
                defenses[i].GetComponent<Defense>().onCooler = false;

                defenses[i].GetComponent<Defense>().enemyToKill = null;
                defenses[i].GetComponent<Defense>().walkingEnemyToKill = null;
                defenses[i].GetComponent<Defense>().flyingEnemyToKill = null;

                defenses[i].transform.position = defenses[i].GetComponent<Defense>().myLocation.position;
                free = true;
            }
        }
    }
}
