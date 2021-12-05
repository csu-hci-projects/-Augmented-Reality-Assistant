using UnityEngine;
using UnityEngine.UI;

public class VisDebug : MonoBehaviour
{
    [SerializeField] private Text visDebug;
    private string[] log;

    private void Start()
    {
        log = new string[5];
        Log("Log Initialized");
    }
    public void Log(string msg)
    {
        Debug.Log(msg);
        AddMessage(msg);
        PrintLog();
    }

    private void AddMessage(string toAdd)
    {
        for(int i = 0; i < log.Length - 1; i++)
        {
            log[i] = log[i + 1];
        }
        log[log.Length - 1] = Time.time + " " + toAdd;
    }

    private void PrintLog()
    {
        var txt = "";
        foreach(var msg in log)
        {
            txt = txt + msg + "\n";
        }
        visDebug.text = txt;
    }
}
