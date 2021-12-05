using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class QuestStep : MonoBehaviour
{
    [SerializeField] private Canvas ui;
    [SerializeField] private Text text;
    [SerializeField] private LineRenderer lr;

    private GameObject cam;

    [SerializeField] private float lineStartWidth = .2f, lineEndWidth = .01f, padding = 0.1f;

    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        ui.worldCamera = cam.GetComponent<Camera>();
        lr = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if(ui.worldCamera != null)
        {
            ui.transform.LookAt(cam.transform);
        }

        if(gameObject.activeInHierarchy == true)
        {
            lr.SetPosition(0, ui.GetComponent<RectTransform>().position);
            lr.SetPosition(1, transform.position);
            lr.startWidth = lineStartWidth;
            lr.endWidth = lineEndWidth;
        }
    }

    public void AdjustCanvasSize()
    {
        StartCoroutine(AdjustCanvasSizeHelper());
    }

    private IEnumerator AdjustCanvasSizeHelper()
    {
        yield return new WaitForEndOfFrame();

        var uiRect = ui.GetComponent<RectTransform>();
        var targetSize = text.GetComponent<RectTransform>();

        uiRect.sizeDelta = new Vector2(uiRect.sizeDelta.x, (targetSize.rect.height * targetSize.localScale.y) + padding);
    }
}

