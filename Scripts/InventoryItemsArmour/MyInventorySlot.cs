using UnityEngine;
using UnityEngine.UI;

public class MyInventorySlot : Slot
{
    public Armour.PossibleArmourSlots ItemSlot { get; private set; }
    [SerializeField]
    private Sprite backupImage;
    [SerializeField]
    private Button button;

    private void Start()
    {
        button.onClick.AddListener(RemoveItem);
        UpdateButton(false);
        var tag = transform.name.Replace("Slot", "");
        ItemSlot = (Armour.PossibleArmourSlots)System.Enum.Parse(typeof(Armour.PossibleArmourSlots), tag);
    }

    public void AddItem(ArmourPiece item)
    {
        this.item = item;
        UpdateButton(true);

        if (item.icon != null)
        {
            icon.sprite = item.icon;
            icon.enabled = true;
        }

        InventoryUI.onItemChangedCallback.Invoke();
    }

    public void RemoveItem()
    {
        icon.sprite = backupImage;
        item = null;
        UpdateButton(false);

        InventoryUI.onItemChangedCallback.Invoke();
    }

    private void UpdateButton(bool state)
    {
        button.enabled = state;
        button.interactable = state;
        button.gameObject.SetActive(state);
    }
}