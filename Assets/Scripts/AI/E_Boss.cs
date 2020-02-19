using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Boss : MonoBehaviour
{
    [Header("Variables")]
    public float f_speedBoss = 1;
    public float damages = 100;

    [Header("Booleans")]
    public bool b_RecoveryOn = false;

    [Header("Animator")]
    public Animator a_BossAnimator;

    [Header("Rigidbody")]
    public Rigidbody r_BossRigidbody;

    [Header("GameObject_ToSpawn")]
    public GameObject g_Mage;
    public GameObject g_Shield;
    public GameObject g_Fantassin;
   

    [Header("GameObject_SpawnPoints")]
    public GameObject g_SpawnPoint_1;
    public GameObject g_SpawnPoint_2;
    public GameObject g_SpawnPoint_3;
    public GameObject g_SpawnPoint_4;
    public GameObject g_SpawnPoint_InvocParticules;

    [Header("Particules")]
    public GameObject g_InvocSpell_Particules;
    public GameObject g_RecoveryDone_Particules;


    void Start()
    {
        Invoke("BossWalking", 1);
        a_BossAnimator.SetBool("Dead", false);
    }

   
    void Update()
    {
    
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "TriggerZone_BossInvoc")
        {
            BossTransition_Walk_to_Invoc();
            Invoke("InvocSpell_Particule",1.8f);
            Invoke("Spell",3.8f);
            Invoke("RecoveryOn", 7);
            Invoke("BossWalking", 8);
        }

        //if (collider.getcomponent<castle>() != null)
        //{
        //    collider.getcomponent<castle>().health -= damages;
        //    destroy(gameobject);
        //}
    }



    // FONCTIONS //




    // fonction permettant au boss de se déplacer.
    private void BossWalking()
    {
        a_BossAnimator.SetFloat("Boss_Speed", 1);
        a_BossAnimator.SetBool("Spell_Used", false);
        r_BossRigidbody.velocity = new Vector3(0, 0, 1) * f_speedBoss;
        Instantiate(g_RecoveryDone_Particules, transform.position, transform.rotation);

    }
    // Fonction de transition d'animation dans laquelle on appelle la fonction de spawn des Ennemis.
    private void BossTransition_Walk_to_Invoc()
    {
        
        r_BossRigidbody.velocity = new Vector3(0, 0, 0);
        a_BossAnimator.SetFloat("Boss_Speed", 0);
        a_BossAnimator.SetBool("Spell_Used", false);
       
    }

    //Fonction du sort d'incation du Boss.
    private void Spell()
    {
        
        Instantiate(g_Mage, g_SpawnPoint_1.transform.position, g_SpawnPoint_1.transform.rotation);
        Instantiate(g_Mage, g_SpawnPoint_2.transform.position, g_SpawnPoint_2.transform.rotation);
        Instantiate(g_Mage, g_SpawnPoint_3.transform.position, g_SpawnPoint_3.transform.rotation);
        Instantiate(g_Mage, g_SpawnPoint_4.transform.position, g_SpawnPoint_4.transform.rotation);
        
    }

    private void InvocSpell_Particule()
    {
        Debug.Log("particules apparaissent");
        Instantiate(g_InvocSpell_Particules, g_SpawnPoint_InvocParticules.transform.position, g_SpawnPoint_InvocParticules.transform.rotation);
        //Destroy(g_InvocSpell_Particules, 2); // TO DO: créer une instance avec un private gameobject de la particule. comme proto
    }

    private void RecoveryOn()
    {
            a_BossAnimator.SetBool("Spell_Used", true);
    }

    //private void Death()
    //{
    //    a_BossAnimator.SetBool("Dead", true);
    //    r_BossRigidbody.velocity = new Vector3(0, 0, 0);
    //    Destroy(gameObject, 4f);
    //}
}
