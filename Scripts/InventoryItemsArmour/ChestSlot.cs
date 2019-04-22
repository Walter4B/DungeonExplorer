using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Generic;

public class ChestSlot : Slot
{
    [SerializeField]
    private Text text;
    [SerializeField]
    private GameObject playerItems;

    public void AddItem()
    {
        var armourSlot = Armour.GetArmour();
        item = ScriptableObject.CreateInstance<ArmourPiece>();
        item.Init(RandomNumberGenerator.GetRandom(Armour.GetArmourValue(armourSlot)), armourSlot);

        UpdateSlot();
    }

    public void AddItemToInvetory()
    {
        var slotToAddTo = playerItems.gameObject.GetComponentsInChildren<MyInventorySlot>()[Armour.GetSlotIndex(item.ArmourSlot)];
        ArmourPiece itemBackup = slotToAddTo.GetArmourPiece();

        slotToAddTo.AddItem(this.item);

        if (itemBackup != null)
        {
            this.item = itemBackup;
            UpdateSlot();
        }
        else
        {
            Object.Destroy(this.gameObject);
        }
    }

    private void UpdateSlot()
    {
        if (item.icon != null)
        {
            icon.sprite = item.icon;
            icon.enabled = true;
        }

        if (text != null)
        {
            text.text = item.name;
            text.enabled = true;
        }
    }
}