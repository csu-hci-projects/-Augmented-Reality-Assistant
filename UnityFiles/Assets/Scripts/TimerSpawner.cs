using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerSpawner : MonoBehaviour
{
    private void Awake()
    {
        var timerInScene = FindObjectOfType<Timer>();
        if(timerInScene == null)
        {
            gameObject.AddComponent<Timer>();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
