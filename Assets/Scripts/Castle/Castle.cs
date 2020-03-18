using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Castle : MonoBehaviour
{
    [Header("Basic Configuration")]
    public float health;
    public GameObject healthBar;
    public static bool loose = false;
    public GameObject defeatScreen;

    private void Awake()
    {
        defeatScreen.SetActive(false);

        healthBar.GetComponent<Slider>().maxValue = health;
        healthBar.GetComponent<Slider>().value = health;
    }

    private void Update()
    {
        if (health <= 0)
        {
            //health = 0;

            defeatScreen.SetActive(true);

            loose = true;
            GameManager.isPaused = true;
        }

        healthBar.GetComponent<Slider>().value = health;
    }
}
