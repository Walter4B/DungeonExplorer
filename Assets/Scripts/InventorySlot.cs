using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Item SlotItem;

    [Header("Slot Buttons")]
    public Button UseButton;
    public Button DropButton;
    public Button SellButton;

    private void Awake()
    {
        //UseButton.onClick.AddListener(UseSlotItem);

        //ClearSlot();
        //AddSlotItem(SlotItem);
    }

    public void UseSlotItem()
    {
        SlotItem.Use();
    }

    public void DropSlotItem()
    {
        Debug.Log("Dropped " + SlotItem.name);
        PlayerCanvasManager.PlayerInventoryInstance.RemoveItem(SlotItem);
    }

    public void SellSlotItem()
    {
        Debug.Log("Money increased: " + SlotItem.Value/2);

        ShopCanvasManager.ShopInventoryInstance.AddItem(SlotItem);
        PlayerCanvasManager.PlayerInventoryInstance.RemoveItem(SlotItem);
    }

    public void ClearSlot()
    {
        SlotItem = null;

        UseButton.image.sprite = null;

        UseButton.interactable = false;
        DropButton.interactable = false;
        SellButton.interactable = false;
    }

    public void AddSlotItem (Item item)
    {
        SlotItem = item;

        UseButton.image.sprite = item.Icon;

        UseButton.interactable = true;
        DropButton.interactable = true;
        SellButton.interactable = true;
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
