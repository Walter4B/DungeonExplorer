using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InventoryPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject PlayerInventory;
    private StatsValues statsValues;
    private MyInventorySlot[] slots;

    private List<ArmourPiece> pieces = null;
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

    private void GenerateItems()
    {
        pieces = new List<ArmourPiece>();
        foreach (var item in slots)
        {
            pieces.Add(item.GetArmourPiece());
        }
    }

    private void UpdateStats()
    {
        GenerateItems();
        stats = new List<string>
        {
            pieces.Where(piece => piece != null).Sum(piece => piece.ArmourValue).ToString(),
            pieces.Where(piece => piece != null).Sum(piece => piece.Stamina).ToString(),
            pieces.Where(piece => piece != null).Sum(piece => piece.Strength).ToString(),
            pieces.Where(piece => piece != null).Sum(piece => piece.Intellect).ToString()
        };

        statsValues.UpdateStats(stats);
    }
}
