using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public delegate void OnItemChanged();
    public static OnItemChanged onItemChangedCallback;
}
