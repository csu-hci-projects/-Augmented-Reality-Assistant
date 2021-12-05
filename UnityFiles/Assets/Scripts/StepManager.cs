using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
public class StepManager : MonoBehaviour
{
    [SerializeField] private Text stepText, counterText;
    [SerializeField] private Transform questLocation;
    [SerializeField] private QuestStep qs;
    [SerializeField] private GameObject exitBTN, nextBTN;

    [SerializeField] private List<string> messages, shortName; //The number of total messages needed to be displayed
    [SerializeField] private List<GameObject> highlight; //This should be the same as messages, but is used to control the location of the messages

    private int currStep = 0; //Keeps track of the current progress
    [SerializeField] private List<GameObject> ALL_HIGHLIGHTS; //Holds references to highlight objects for activation and deactivation in hierarchy

    private void Start()
    {
        SetStepCount();
        stepText.text = messages[0];
    }

    private void SetStepCount()
    {
        counterText.text = currStep + 1 + " / " + messages.Count;
    }

    //Changes to specified step
    public void SetStep(int step)
    {
        try
        {
            stepText.text = messages[step];
            qs.AdjustCanvasSize();

            if(ALL_HIGHLIGHTS.Count != 0)
            {
                foreach(var obj in ALL_HIGHLIGHTS)
                {
                    if (obj != null)
                    {
                        obj.SetActive(false);
                    }
                }
            }

            highlight[step].SetActive(true);
            questLocation = highlight[step].transform;

            qs.transform.position = questLocation.position;

            currStep = step;
            SetStepCount();
            CheckStep(currStep);
        }
        catch (Exception error)
        {
            Debug.Log(error.Message);
        }
    }

    //Progress to the next step
    public void nextStep()
    {
        if (currStep + 1 <= messages.Count - 1)
        {
            SetStep(currStep + 1);
        }
        /*try{
            stepText.text = messages[currStep + 1];
            qs.AdjustCanvasSize();

            if (ALL_HIGHLIGHTS.Count != 0)
            {
                foreach (var obj in ALL_HIGHLIGHTS)
                {
                    if (obj != null)
                    {
                        obj.SetActive(false);
                    }
                }
            }

            highlight[currStep + 1].SetActive(true);
            questLocation = highlight[currStep + 1].transform;

            qs.transform.position = questLocation.position;

            currStep++;
            SetStepCount();
            CheckStep(currStep);
        }
        catch(Exception error)
        {
            Debug.Log(error.Message);
        }*/
    }

    //Return to the previous step
    public void prevStep()
    {
        if (currStep - 1 >= 0)
        {
            SetStep(currStep - 1);
        }
        /*try
        {
            stepText.text = messages[currStep - 1];
            qs.AdjustCanvasSize();
            
            if(ALL_HIGHLIGHTS.Count != 0)
            {
                foreach (var obj in ALL_HIGHLIGHTS)
                {
                    if(obj != null)
                    {
                        obj.SetActive(false);
                    }
                }
            }

            highlight[currStep - 1].SetActive(true);
            questLocation = highlight[currStep - 1].transform;

            qs.transform.position = questLocation.position;

            currStep--;
            SetStepCount();
            CheckStep(currStep);
        }
        catch (Exception error)
        {
            Debug.Log(error.Message);
        }*/
    }

    public void ExitTraining(string sceneToLoad)
    {
        try
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        catch(Exception error)
        {
            Debug.Log(error.Message);
        }
    }

    private void CheckStep(int step)
    {
        if(step == messages.Count - 1)
        {
            exitBTN.SetActive(true);
            nextBTN.SetActive(false);
        }
        else
        {
            exitBTN.SetActive(false);
            nextBTN.SetActive(true);
        }
    }
}
