using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    //[SerializeField] private Text txt;
    //private Timer timer;

    //private void Start()
    //{
    //    timer = FindObjectOfType<Timer>();
    //}

    public void LaunchModule(string toLaunch)
    {
        SceneManager.LoadScene(toLaunch);
    }

    //public void TimerStart()
    //{
    //    timer.StartTimer();
    //}

    //public void CheckTimer()
    //{
    //    txt.text = "Time To Complete: " + timer.GetTime() + "s";
    //}
}
