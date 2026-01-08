using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour
{
    private static ToolTip instance;

    [SerializeField]
    private Camera uiCamera;

    public Text tooltipText;
    public RectTransform backgroundRectTransform;

    private void Awake()
    {
        instance = this;
        HideTooltip();
    }

    private void Update()
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent.GetComponent<RectTransform>(), Input.mousePosition, uiCamera, out localPoint);

        backgroundRectTransform.localPosition = localPoint;
    }

    private void ShowToolTip(string tooltipString)
    {
        gameObject.SetActive(true);

        tooltipText.text = tooltipString;
        float PaddingSize = 4f;
        Vector2 backGroundSize = new Vector2(tooltipText.preferredWidth + PaddingSize * 2f, tooltipText.preferredHeight + PaddingSize * 2f);
        backgroundRectTransform.sizeDelta = backGroundSize;
    }

    private void HideTooltip()
    {
        gameObject.SetActive(false);
    }

    public static void ShowTooltip_Static(string tooltipString)
    {
        instance.ShowToolTip(tooltipString);
    }
    public static void HideTooltip_Static()
    {
        instance.HideTooltip();
    }
}