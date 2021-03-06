﻿using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using System.Collections.Generic;

public class ChestSlot : Slot
{
    [SerializeField]
    private TextMeshProUGUI text;
    private GameObject playerItems;

    private void Awake()
    {
        playerItems = GameObject.FindGameObjectWithTag("CharacterInventory");
    }

    public void AddItem()
    {
        var armourSlot = Armour.GetArmour();
        item = ScriptableObject.CreateInstance<ArmourPiece>();
        item.Init(RandomNumberGenerator.GetRandom(Armour.GetArmourValue(armourSlot)), armourSlot);

        UpdateSlot();
    }

    public void AddItemToInvetory()
    {
        if (playerItems == null)
        {
            this.Awake();
        }

        var slotToAddTo = playerItems.gameObject.GetComponentsInChildren<MyInventorySlot>()[Armour.GetSlotIndex(item.ArmourSlot)];
        ArmourPiece itemBackup = slotToAddTo.GetArmourPiece();

        if (slotToAddTo != null)
            slotToAddTo.AddItem(this.item);
        else
            Debug.Log("ERROR!");

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