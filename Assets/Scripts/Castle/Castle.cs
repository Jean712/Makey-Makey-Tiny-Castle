using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Castle : MonoBehaviour
{
    [Header("Basic Configuration")]
    public float health;
    public GameObject healthBar;

    private void Awake()
    {
        Scene scene = SceneManager.GetActiveScene();
        GameManager.currentLevel = scene.buildIndex;

        healthBar.GetComponent<Slider>().maxValue = health;
        healthBar.GetComponent<Slider>().value = health;
    }

    private void Update()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene("Defeat");
        }

        healthBar.GetComponent<Slider>().value = health;
    }
}
