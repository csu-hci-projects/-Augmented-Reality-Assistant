using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupController : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private Text text;
    [SerializeField] private float padding = 0.1f;
    //[SerializeField] private GameObject attachedHighlight;

    private GameObject cam;

    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        canvas.worldCamera = cam.GetComponent<Camera>();

        var canvasRect = canvas.GetComponent<RectTransform>();
        var targetSize = text.GetComponent<RectTransform>();

        canvasRect.sizeDelta = new Vector2(canvasRect.sizeDelta.x, (targetSize.rect.height * targetSize.localScale.y) + padding);

        canvas.GetComponent<RectTransform>().position = gameObject.transform.position;

        /*canvas.transform.position = new Vector3 (attachedHighlight.transform.position.x,
                                                 attachedHighlight.transform.position.y + ((canvasRect.rect.height / 2) + padding),
                                                 attachedHighlight.transform.position.z);*/
    }

    private void Update()
    {
        if(canvas.worldCamera != null)
        {
            canvas.transform.LookAt(cam.transform);
        }
    }
}
