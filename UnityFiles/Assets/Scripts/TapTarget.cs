using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapTarget : MonoBehaviour
{
    [SerializeField] GameObject infoPopup;
    public void TargetSelect()
    {
        infoPopup.SetActive(!infoPopup.activeInHierarchy);
    }
}
