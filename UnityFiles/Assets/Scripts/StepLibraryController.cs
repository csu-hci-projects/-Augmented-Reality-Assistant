using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StepLibraryController : MonoBehaviour
{
    [SerializeField] private Button openButton;
    [SerializeField] private GameObject stepLibMenu;
    [SerializeField] private StepManager stepManager;
    public void LibraryActive(bool active) //Used to activate and deactivate when the image target is detected
    {
        openButton.gameObject.SetActive(active);
        if (!active)
        {
            stepLibMenu.SetActive(false);
        }
    }

    public void ToggleLibrary() //Used to toggle the menu UI when a button is pushed or if the user selects a step to jump to
    {
        stepLibMenu.SetActive(!stepLibMenu.activeInHierarchy);
    }

    public void SelectStep(int stepInt)
    {
        stepManager.SetStep(stepInt);
        ToggleLibrary();
    }
}
