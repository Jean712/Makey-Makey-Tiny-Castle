using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Castle : MonoBehaviour
{
    [Header("Basic Configuration")]
    public float health;
    public GameObject healthBar;

    private void Awake()
    {
        healthBar.GetComponent<Slider>().maxValue = health;
        healthBar.GetComponent<Slider>().value = health;
    }

    private void Update()
    {
        if (health <= 0)
        {
            health = 0;
            Debug.Log("Perdu");
        }
    }

    public void Damaged()
    {
        healthBar.GetComponent<Slider>().value = health;
    }
}
