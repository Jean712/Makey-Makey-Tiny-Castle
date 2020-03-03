using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Healer : MonoBehaviour
{
    public GameObject healZone;
    public GameObject spawnPoint;

    public Transform target;
    public Transform mySelf;

    //public float degreesPerSecond;
    public float turnSpeed = 10;
    public float TimeBeforeRotate = 0f;
    public float TimeBeforeHeal = 0f;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider tz_Heal)
    {
        if(tz_Heal.gameObject.name == "tz_Healer")
        {
            GetComponent<Enemy>().rgbd.velocity = new Vector3(0, 0, 0);
            Invoke("HerosNeverDie", TimeBeforeHeal);

            GetComponent<Enemy>().amtr.SetFloat("Speed", 0);
            GetComponent<Enemy>().amtr.SetBool("Dead", false);
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name == "tz_Healer")
        {
            Invoke("lookAt", TimeBeforeRotate);
        }
    }

    public void HerosNeverDie()
    {      
        Instantiate(healZone, spawnPoint.transform.position, spawnPoint.transform.rotation);
    }

    public void lookAt()
    {
        //transform.LookAt(target); //au cas ou le propre ne fonctionne pas.

        //Vector3 direction = target.position - transform.position;
        //Quaternion toRotation = Quaternion.FromToRotation(transform.forward, direction);
        //transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, turnSpeed * Time.time);

        Vector3 dir = target.position - transform.position;
        Quaternion lookrotation = Quaternion.LookRotation(dir);
        mySelf.rotation = Quaternion.Lerp(mySelf.rotation, lookrotation, Time.deltaTime * turnSpeed);

        //Vector3 dir = target.position - transform.position;
        //Quaternion lookRotation = Quaternion.LookRotation(dir);
        //Vector3 rotation = Quaternion.Lerp(mySelf.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        //mySelf.rotation = Quaternion.Euler(0f, rotation.y, 0f);


        //Vector3 dirFromMeToTarget = target.position - transform.position;
        //dirFromMeToTarget.y = 0.0f;
        //Quaternion lookRotation = Quaternion.LookRotation(dirFromMeToTarget);
        //transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * (turnSpeed / 20.0f));
    }
}
