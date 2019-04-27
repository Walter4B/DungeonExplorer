﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InventoryPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject PlayerInventory;
    private StatsValues statsValues;

    [SerializeField]
    private MyInventorySlot[] slots;

    private List<string> stats = null;

    private void Awake()
    {
        InventoryUI.onItemChangedCallback += UpdateStats;
        statsValues = PlayerInventory.GetComponentInChildren<StatsValues>();
        slots = PlayerInventory.GetComponentsInChildren<MyInventorySlot>();
        PlayerInventory.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            PlayerInventory.SetActive(!PlayerInventory.activeSelf);
        }
    }

    public List<ArmourPiece> GetItemsFromSlots()
    {
        return slots.Select(slot => slot.GetArmourPiece()).ToList();
    }

    public void UpdateStats()
    {
        stats = new List<string>
        {
            slots.Select(slot => slot.GetArmourPiece()).Where(piece => piece != null).Sum(piece => piece.ArmourValue).ToString(),

            (slots.Select(slot => slot.GetArmourPiece()).Where(piece => piece != null).Sum(piece => piece.Stamina) + 10).ToString(),
            slots.Select(slot => slot.GetArmourPiece()).Where(piece => piece != null).Sum(piece => piece.Strength).ToString(),
            slots.Select(slot => slot.GetArmourPiece()).Where(piece => piece != null).Sum(piece => piece.Intellect).ToString()
        };

        statsValues.UpdateStats(stats);
    }
}
