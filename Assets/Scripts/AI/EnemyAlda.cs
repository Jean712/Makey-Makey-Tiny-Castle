using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAlda : MonoBehaviour
{
    [Header("Variables")]
    public float health;

    [Header("Animator")]
    public Animator a_BossAnimator;
    public Animator a_MageAnimator;

    [Header("Rigidbody")]
    public Rigidbody r_BossRigidbody;
    public Rigidbody r_MageRigidbody;

    void Start()
    {
        
    }


    void Update()
    {
        if (health <= 0)
        {
            Death(); 
        }
    }

    private void Death()
    {
        // Boss
        a_BossAnimator.SetBool("Dead", true);
        r_BossRigidbody.velocity = new Vector3(0, 0, 0);

        //Mage
        a_MageAnimator.SetBool("Dead", true);
        r_MageRigidbody.velocity = new Vector3(0, 0, 0);

        Destroy(gameObject, 4f);
    }
}   
