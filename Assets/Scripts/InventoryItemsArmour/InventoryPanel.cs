using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InventoryPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject PlayerInventory;
    [SerializeField]
    private StatsValues statsValues;

    private List<ArmourPiece> pieces = null;
    private List<string> stats = null;

    [SerializeField]
    private MyInventorySlot[] slots;

    private void Start()
    {
        InventoryUI.onItemChangedCallback += UpdateStats;
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
