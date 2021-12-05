using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverlayController : MonoBehaviour
{
    private Text text;
    [SerializeField] private string initialScanMessage = "Scan an image with your camera!", lostTrackingMessage = "Image has been lost! Rescan the image to resume.";

    private void Start()
    {
        text = GetComponent<Text>();
    }

    public void ImageFound()
    {
        HideText(true);
    }

    public void ImageLost()
    {
        HideText(false);
    }

    private void HideText(bool shouldHide)
    {
        if (shouldHide)
        {
            text.text = "";
        }
        else
        {
            text.text = lostTrackingMessage;
        }
    }
}
