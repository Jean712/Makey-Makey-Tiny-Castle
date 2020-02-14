﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody rgbd;

    public float health;
    public float damages;

    private void Awake()
    {
        rgbd = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rgbd.velocity = -Vector3.forward;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Castle>() != null)
        {
            other.GetComponent<Castle>().health -= damages;
            Destroy(gameObject);
        }
    }
}