using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Variables")]
    public float health = 1;
    public float damages = 1;
    public float speed = 1;
    public float healingDelay = 0;

    public bool flying;

    [HideInInspector]
    public Animator amtr;

    [HideInInspector]
    public Rigidbody rgbd;

    private void Awake()
    {
        rgbd = GetComponent<Rigidbody>();
        amtr = GetComponent<Animator>();

        amtr.SetBool("Dead", false);
        amtr.SetFloat("Speed", 1);

        rgbd.velocity += new Vector3(0, 0, 1) * speed;
    }
    
    private void Update()
    {
        healingDelay += Time.deltaTime * 1;
        if (healingDelay >= 2)
        {
            healingDelay = 0;
        }

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

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<P_Heal>() != null & healingDelay > 1.9f & healingDelay <1.91111f)
        {
            health += 1f;
        }
    }

    private void Death()
    {
        amtr.SetBool("Dead", true);
        rgbd.velocity = new Vector3(0, 0, 0);

        Destroy(gameObject, 2f);
    }
}