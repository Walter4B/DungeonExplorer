using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Item SlotItem;

    [Header("Slot Properties")]
    public Image SlotItemImage;
    public Button BuyButton;

    public void ClearSlot()
    {
        SlotItem = null;

        SlotItemImage.sprite = null;

        BuyButton.interactable = false;
    }

    public void AddSlotItem (Item item)
    {
        SlotItem = item;

        SlotItemImage.sprite = item.Icon;

        BuyButton.interactable = true;
    }

    public void BuySlotItem()
    {
        Debug.Log("Money reduced: " + SlotItem.Value);

        PlayerCanvasManager.PlayerInventoryInstance.AddItem(SlotItem);
        ShopCanvasManager.ShopInventoryInstance.RemoveItem(SlotItem);
    }
    public void OnPointerEnter(PointerEventData evenData)
    {
        TooltipCanvasManager.Instance.EnableTooltip(SlotItem);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipCanvasManager.Instance.DisableTooltip();
    }
}
