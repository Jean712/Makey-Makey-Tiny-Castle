using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Boss : MonoBehaviour
{
    [Header("Booleans")]
    public bool recovery = false;

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
        Invoke("BossWalking", 1);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "tz_BossInvoc")
        {
            BossTransition_Walk_to_Invoc();
            Invoke("InvocSpellParticule", 1.8f);
            Invoke("Spell", 3.8f);
            Invoke("RecoveryOn", 7);
            Invoke("BossWalking", 8);
        }
    }

    // FONCTIONS

    // Fonction permettant au boss de se déplacer.
    private void BossWalking()
    {
        GetComponent<Enemy>().amtr.SetFloat("Boss_Speed", 1);
        GetComponent<Enemy>().amtr.SetBool("Spell_Used", false);

        GetComponent<Enemy>().rgbd.velocity += Vector3.forward * GetComponent<Enemy>().speed;

        Instantiate(recoveryDone_Particules, transform.position, transform.rotation);
    }

    // Fonction de transition d'animation dans laquelle on appelle la fonction de spawn des Ennemis.
    private void BossTransition_Walk_to_Invoc()
    {
        GetComponent<Enemy>().rgbd.velocity = Vector3.zero;

        GetComponent<Enemy>().amtr.SetFloat("Boss_Speed", 0);
        GetComponent<Enemy>().amtr.SetBool("Spell_Used", false);
    }

    // Fonction du sort d'incation du Boss.
    private void Spell()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            Instantiate(enemies[i], spawnPoints[i].transform.position, spawnPoints[i].transform.rotation);
        }
    }

    private void InvocSpellParticule()
    {
        Debug.Log("particules apparaissent");
        Instantiate(invocSpell_Particules, spawnPointParticules.transform.position, spawnPointParticules.transform.rotation);
    }

    private void RecoveryOn()
    {
        GetComponent<Enemy>().amtr.SetBool("Spell_Used", true);
    }
}
