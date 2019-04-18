using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopCanvasManager : MonoBehaviour
{
    public ShopSlot ShopSlotPrefab;

    public Transform ShopPanel;

    //inace ovo bi trebalo bit u shop, npc, etc.
    public Inventory ShopInventory;

    public static Inventory ShopInventoryInstance;

    [Header("Read-only")]
    [SerializeField]
    private List<ShopSlot> _shopSlots = new List<ShopSlot>();

    private void Awake()
    {
        ShopInventoryInstance = ShopInventory;

        CreateShopSlot();
        UpdateShopCanvas();

        ShopInventory.OnInventoryChange.AddListener(UpdateShopCanvas);
    }

    private void CreateShopSlot()
    {
        for (int i = 0; i < ShopInventory.Size; i++)
        {
            ShopSlot shopSlotClone = Instantiate(ShopSlotPrefab, ShopPanel);
            shopSlotClone.ClearSlot();

            _shopSlots.Add(shopSlotClone);
        }
    }

    private void UpdateShopCanvas()
    {
        for (int i = 0; i < _shopSlots.Count; i++)
        {
            if (i < ShopInventory.Items.Count)
                _shopSlots[i].AddSlotItem(ShopInventory.Items[i]);
            else
                _shopSlots[i].ClearSlot();
        }
    }
}
