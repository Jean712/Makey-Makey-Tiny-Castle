using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Boss : MonoBehaviour
{
    [Header("GameObject_ToSpawn")]
    public GameObject[] enemies;

    [Header("GameObject_SpawnPoints")]
    public GameObject[] spawnPoints;
    public GameObject spawnPointParticules;

    [Header("Particules")]
    public GameObject invocSpell_Particules;
    public GameObject recoveryDone_Particules;

    void Start()
    {
        //Invoke("BossWalking", 1);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "tz_BossInvoc")
        {
            IdleBoss();
            //Invoke("InvocSpellParticule", 1.8f);
            //Invoke("Spell", 3.8f);
            //Invoke("RecoveryOn", 7);
            //Invoke("BossWalking", 8);
        }
    }

    // FONCTIONS

    // Fonction permettant au boss de se déplacer.
    public void BossWalking()
    {
        GetComponent<Enemy>().amtr.SetFloat("Speed", 1);

        GetComponent<Enemy>().rgbd.velocity += Vector3.forward * GetComponent<Enemy>().speed;
    }

    // Fonction de transition d'animation dans laquelle on appelle la fonction de spawn des Ennemis.
    public void IdleBoss()
    {
        GetComponent<Enemy>().rgbd.velocity = Vector3.zero;

        GetComponent<Enemy>().amtr.SetFloat("Speed", 0);
    }

    // Fonction du sort d'incation du Boss.
    public void Spell()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            Instantiate(enemies[i], spawnPoints[i].transform.position, spawnPoints[i].transform.rotation);

        }
    }

    public void InvocSpellParticule()
    {
        Instantiate(invocSpell_Particules, spawnPointParticules.transform.position, spawnPointParticules.transform.rotation);
    }

    public void RecoveryOn()
    {
        Instantiate(recoveryDone_Particules, transform.position, transform.rotation);
    }
}
