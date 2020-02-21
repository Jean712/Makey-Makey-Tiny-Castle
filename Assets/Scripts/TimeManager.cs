using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [Header("Developer Only")]
    [Range(0, 100)]
    public float timeScale = 1;

    void Update()
    {
        Time.timeScale = timeScale;
    }
}
    