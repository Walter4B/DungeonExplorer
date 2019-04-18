using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Inventory 
{
    public int Size = 25;

    [Header("Read-only")]
    [SerializeField]
    private List<Item> _items = new List<Item>();

    public List<Item> Items
    {
        get
        {
            //pripaziti jer se vraca referenca
            //dobro bi bilo da _items radi sa AsReadOnly

            return _items;
        }
    }
    public UnityEvent OnInventoryChange = new UnityEvent();

    public bool RemoveItem (Item item)
    {
        bool  wasItemRemoved = _items.Remove(item);

        OnInventoryChange.Invoke();

        return wasItemRemoved;
    }

    public bool AddItem(Item item)
    {
        if (_items.Count < Size)
        {
            _items.Add(item);
            OnInventoryChange.Invoke();

            return true;
        }
        else
        {
            Debug.Log("Inventory is full");

            return false;
        }
    }
}
