using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemPanel : MonoBehaviour
{
    public GameObject itemPanel;
    public PanelValues panelValues;
    public Slot slot;

    private void Start()
    {
        InventoryUI.onItemChangedCallback += ClosePanel;
        itemPanel.SetActive(false);
    }

    public void ShowPanel()
    {
        var armourPiece = slot.GetArmourPiece();

        if (armourPiece != null)
        {
            panelValues.UpdateValues(armourPiece);
            itemPanel.SetActive(true);
        }
    }

    public void ClosePanel()
    {
        itemPanel.SetActive(false);
    }
}
