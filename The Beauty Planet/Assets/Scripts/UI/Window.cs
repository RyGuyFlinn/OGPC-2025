using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Window : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Button slotButton;
    public string itemText;

    // Called when the mouse enters the button
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (itemText != "")
        {
            ToolTip.ShowTooltip_Static(itemText);
        }
    }

    // Called when the mouse exits the button
    public void OnPointerExit(PointerEventData eventData)
    {
        ToolTip.HideTooltip_Static();
    }
}