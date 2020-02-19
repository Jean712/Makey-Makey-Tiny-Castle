using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [Header("Variables")]
    public float health;
    public float damages;

    [Header("Animator")]
    public Animator a_EnemyAnimator;

    [Header("Rigidbody")]
    private Rigidbody r_EnemyRigidbody;

    private void Awake()
    {
        r_EnemyRigidbody = GetComponent<Rigidbody>();
        a_EnemyAnimator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (health <= 0)
        {
            Death();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Castle>() != null)
        {
            other.GetComponent<Castle>().health -= damages;

        }
    }


    private void Death()
    {
        // Boss
        a_EnemyAnimator.SetBool("Dead", true);
        r_EnemyRigidbody.velocity = new Vector3(0, 0, 0);

        Destroy(gameObject, 4f);
    }
}