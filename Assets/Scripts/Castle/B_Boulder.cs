using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_Boulder : MonoBehaviour
{
    private Rigidbody rgbd;
    private float initialForce;
    public float initialBoost;
    [Range(0, -90)]
    public float shootingPlaceAngle;

    public float damages;
    public float blastRadius;
    private GameObject[] allEnemies;

    private void Awake()
    {
        rgbd = GetComponent<Rigidbody>();

        initialForce = Mathf.Sqrt((D_Catapult.d_CatapultDistance / Mathf.Sin(2 * shootingPlaceAngle)) * Physics.gravity.magnitude) * initialBoost;
        rgbd.AddForce(transform.forward * initialForce, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>() != null)
        {
            other.GetComponent<Enemy>().health -= damages;
            AOE();

            Destroy(gameObject);
        }

        if (other.name == "Floor")
        {
            AOE();

            Destroy(gameObject);
        }
    }

    private void AOE()
    {
        allEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject item in allEnemies)
        {
            if (blastRadius >= Vector3.Distance(transform.position, item.transform.position))
            {
                item.GetComponent<Enemy>().health -= damages;
            }
        }
    }
}
