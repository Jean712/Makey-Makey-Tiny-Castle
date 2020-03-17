using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_Cauldron : MonoBehaviour
{
    //[HideInInspector]
    //public GameObject actualEnemy1;
    //[HideInInspector]
    //public GameObject actualEnemy2;
    //[HideInInspector]
    //public GameObject[] enemies;
    //private List<GameObject> enemiesToCheck;

    [Header("Basic Configuration")]
    public GameObject lava;
    public GameObject lavaLevel;
    public Animator amtr;
    public KeyCode myInput;
    //public GameObject target;
    public bool active;
    public float distance = 1;
    public float maxDamages;
    private float damages;
    public float cooldown;
    private float timer;

    private void Awake()
    {
        timer = cooldown;
        //enemiesToCheck = new List<GameObject>();

        transform.Find("Target").GetComponent<GizmoCreator>().gizmoSize = distance;    // Developer Only //
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= cooldown)
        {
            timer = cooldown;
        }

        if (Input.GetKeyDown(myInput) && !active)
        {
            amtr.Play("Attack");

            active = true;
            damages = timer / cooldown * maxDamages;
            lava.GetComponent<Lava>().damages = damages;

            lavaLevel.SetActive(false);

            //foreach (GameObject item in enemies)
            //{
            //    enemiesToCheck.Add(item);
            //}

            //if (actualEnemy1 != null && actualEnemy2 != null)
            //{
            //    enemiesToCheck.Add(actualEnemy1);
            //    enemiesToCheck.Add(actualEnemy2);
            //}

            //foreach (GameObject item in enemiesToCheck)
            //{
            //    if (distance >= Vector3.Distance(target.transform.position, item.transform.position) && !item.GetComponent<Enemy>().flying)
            //    {
            //        item.GetComponent<Enemy>().health -= damages;

            //        Debug.Log(item);
            //    }
            //}
        }

        if (active)
        {
            lava.transform.position = Vector3.Lerp(lava.transform.position, new Vector3(0, 0, distance), 0.05f);

            StartCoroutine(LavaMovement(3));
        }
        else
        {

        lavaLevel.transform.position = new Vector3(0, timer / cooldown + 3.5f, 2.5f);
        }
    }

    IEnumerator LavaMovement(float time)
    {
        yield return new WaitForSeconds(time);

        lava.transform.position = Vector3.Lerp(lava.transform.position, lava.transform.position + Vector3.down / 4, 0.05f);

        active = false;

        yield return new WaitForSeconds(time);

        lava.transform.position = new Vector3(0, 0, -2);
        lavaLevel.SetActive(true);
        timer = 0;
    }
}
