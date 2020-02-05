using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage_Manager : MonoBehaviour
{
    public float _speed = 2;
    public float _life = 10;
    public float _damege = 10;

    public GameObject Projectile_Attaque;
    public GameObject DeathParticules;
    public GameObject MageZoneAttack;

    public Rigidbody MageRigidbody;

    public bool IsMouving = false;
    public bool IsFighting = false;
    public bool IsDying = false;

    public Animator DistanceMinionAnimator;

    void Start()
    {
        MageRigidbody.velocity += new Vector3(0, 0, 1) * _speed;
        DistanceMinionAnimator.SetFloat("Speed", 1);     
    }

    
    void Update()
    {

        if(_life < 1)
        {
            IsDying = true;
            // Placer animation. Durée 1s avant le despawn + Instancier les particules + les dispawn après X temps. 
            Destroy(gameObject, 1);
        }

        if(IsFighting == true)
        {
            Instantiate(Projectile_Attaque, transform.position, transform.rotation);
        }
     
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "TriggerZone_MageAttackZone")
        {
            IsFighting = true;
            MageRigidbody.velocity = new Vector3(0, 0, 0);
            DistanceMinionAnimator.SetFloat("Speed", 0);
        }
    }

}
