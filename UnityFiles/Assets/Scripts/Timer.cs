using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    private float seconds = 0f;
    private bool timerStart = false;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        var scene = SceneManager.GetActiveScene();
        if (timerStart)
        {
            seconds += Time.deltaTime;
        }else if(scene.name == "Menu")
        {
            StopTimer();
        }
    }

    public void StartTimer()
    {
        timerStart = true;
    }

    private void StopTimer()
    {
        timerStart = false;
    }

    public float GetTime()
    {
        return seconds;
    }
}
