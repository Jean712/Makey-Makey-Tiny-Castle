using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Storm : MonoBehaviour
{
    public GameObject storm;
    void Update()
    {
        storm.transform.Rotate(0.0f, 0.0f, -12.0f);
    }
}
