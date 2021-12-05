using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasResizeTest : MonoBehaviour
{
    [SerializeField] private Canvas ui;
    [SerializeField] private float targetSize = 1f;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Spacebar has been pressed");

            var rect = ui.transform.GetComponent<RectTransform>();
            rect.sizeDelta = new Vector2(rect.sizeDelta.x, rect.sizeDelta.x);
        }
    }
}
