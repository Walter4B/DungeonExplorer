using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// samo helper inace se radi u skrinji, shopu etc.
public class ItemInstantiatorHelper : MonoBehaviour
{
    public List<Item> PlayerItemAssets = new List<Item>();
    public List<Item> ShopItemAssets = new List<Item>();

    private void Start()
    {
        foreach (Item playerItemAsset in PlayerItemAssets)
        {
            Item playerItemClone = ScriptableObject.Instantiate(playerItemAsset);
            PlayerCanvasManager.PlayerInventoryInstance.AddItem(playerItemClone);
        }

        foreach (Item shopItemAsset in ShopItemAssets)
        {
            Item shopItemClone = ScriptableObject.Instantiate(shopItemAsset);
            ShopCanvasManager.ShopInventoryInstance.AddItem(shopItemClone);
        }
    }
}
