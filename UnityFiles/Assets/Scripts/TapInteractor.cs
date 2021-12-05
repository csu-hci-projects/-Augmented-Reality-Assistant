using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapInteractor : MonoBehaviour
{
    [SerializeField] Camera ARCam;

    private void Start()
    {
        ARCam = Camera.allCameras[0];
    }

    private void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            var ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                TapTarget target;
                if (hit.transform.TryGetComponent<TapTarget>(out target))
                {
                    target.TargetSelect();
                }
            }
        }
    }
}
