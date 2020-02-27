using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_Cauldron : MonoBehaviour
{
    [HideInInspector]
    public GameObject actualEnemy1;
    [HideInInspector]
    public GameObject actualEnemy2;
    [HideInInspector]
    public GameObject[] enemies;
    private List<GameObject> enemiesToCheck;

    [Header("Basic Configuration")]
    public KeyCode myInput;
    public GameObject target;
    public float distance = 1;
    public float maxDamages;
    private float damages;
    public float cooldown;
    private float timer;

    private void Awake()
    {
        timer = cooldown;
        enemiesToCheck = new List<GameObject>();

        transform.Find("Target").GetComponent<GizmoCreator>().gizmoSize = distance;    // Developer Only //
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= cooldown)
        {
            timer = cooldown;
        }

        if (Input.GetKeyDown(myInput))
        {
            damages = timer / cooldown * maxDamages;

            foreach (GameObject item in enemies)
            {
                enemiesToCheck.Add(item);
            }

            if (actualEnemy1 != null && actualEnemy2 != null)
            {
                enemiesToCheck.Add(actualEnemy1);
                enemiesToCheck.Add(actualEnemy2);
            }

            foreach (GameObject item in enemiesToCheck)
            {
                if (distance >= Vector3.Distance(target.transform.position, item.transform.position) && !item.GetComponent<Enemy>().flying)
                {
                    item.GetComponent<Enemy>().health -= damages;
                }
            }

            timer = 0;
        }
    }
}
