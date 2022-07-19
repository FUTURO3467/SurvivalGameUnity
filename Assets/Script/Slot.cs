using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
    public ItemData item;
    public Image visual;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (item == null) return;

        ToolTipSystem.instance.Show(item.description, item.name);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        ToolTipSystem.instance.Hide();
    }

    public void ClickOnSlot()
    {
        Inventory.instance.OpenActionPanel(item, transform.position);
    }

}
