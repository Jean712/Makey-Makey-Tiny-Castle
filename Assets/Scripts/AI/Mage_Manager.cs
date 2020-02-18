using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage_Manager : MonoBehaviour
{
    public float _speed = 2;
    public float _life = 10;
    public float _damege = 10;
    public float _rateOffFire = 0;

    public GameObject g_Projectile_Attaque;
    public GameObject g_DeathParticules;
    public GameObject g_pointSpawnProjectile;

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
        DeathMage();
        MageAttack();

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

    // FUCTIONS

    void MageAttack()
    {

        if(IsFighting == true)
        {
            Debug.Log("jme tape");
            _rateOffFire += 1 * Time.deltaTime;
        }
        if (_rateOffFire > 2.5f)
        {
            Debug.Log("Lavitesse d'attaque est à 1 dude");
            Instantiate(g_Projectile_Attaque, g_pointSpawnProjectile.transform.position, g_pointSpawnProjectile.transform.rotation);
            _rateOffFire = 0;
        }
    }

    void DeathMage()
    {
        if (_life < 1)
        {
            IsDying = true;
            // Placer animation. Durée 1s avant le despawn + Instancier les particules + les dispawn après X temps. 
            Destroy(gameObject, 1);
        }
    }

}
