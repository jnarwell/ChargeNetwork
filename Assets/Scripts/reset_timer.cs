using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reset_timer : MonoBehaviour
{
    public int timerval = 0;
    private void Start()
    {
        InvokeRepeating("timer", 0, 1.0f);

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            timerval = 0;
        }
    }

    void timer()
    {
        timerval++;

        if (timerval == 120)
        {
            SceneManager.LoadScene("Start_Scene");
        }
    }

}
