using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCanvasManager : MonoBehaviour
{
    public InventorySlot InventorySlotPrefab;

    public Transform InventoryPanel; 

    //inace ovo bi trebalo bit u playeru
    public Inventory PlayerInventory;

    public static Inventory PlayerInventoryInstance;

    [Header("Read-only")]
    [SerializeField]
    private List<InventorySlot> _inventorySlots = new List<InventorySlot>();

    private void Awake()
    {
        PlayerInventoryInstance = PlayerInventory;

        CreateInventorySlot();
        UpdateInventoryCanvas();

        PlayerInventory.OnInventoryChange.AddListener(UpdateInventoryCanvas);
    }

    private void CreateInventorySlot()
    {
        for (int i = 0; i < PlayerInventory.Size; i++)
        {
            InventorySlot inventorySlotClone = Instantiate(InventorySlotPrefab, InventoryPanel);
            inventorySlotClone.ClearSlot();

            _inventorySlots.Add(inventorySlotClone);
        }
    }

    private void UpdateInventoryCanvas()
    {
        for(int i = 0; i < _inventorySlots.Count; i++)
        {
            if (i < PlayerInventory.Items.Count)
                _inventorySlots[i].AddSlotItem(PlayerInventory.Items[i]);
            else
                _inventorySlots[i].ClearSlot();
        }
    }
}
