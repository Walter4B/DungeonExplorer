using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class CommanChest : MonoBehaviour
{
    [SerializeField]
    private Transform parentCanvasTransform;
    [SerializeField]
    private GameObject chestPanel;
    [SerializeField]
    private Transform Player;

    private readonly float radius = 2.5f;
    private float distance;
    private enum Clickable { ChestClicked, ChestNotClicked, DidntClick }

    private GameObject copyPanel;

    private ChestSlot[] slots;

    private void Start()
    {
        copyPanel = Instantiate(chestPanel, parentCanvasTransform);
        copyPanel.SetActive(false);
        slots = copyPanel.GetComponentsInChildren<ChestSlot>();

        foreach (var item in slots)
        {
            item.AddItem();
        }
    }

    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        distance = Vector2.Distance(Player.position, transform.position);

        if (distance < radius && CheckIfClicked() == Clickable.ChestClicked)
        {
            copyPanel.SetActive(!copyPanel.activeSelf);
        }

        if (copyPanel.activeSelf && (distance > radius || CheckIfClicked() == Clickable.ChestNotClicked))
        {
            copyPanel.SetActive(false);
        }
    }


    private Clickable CheckIfClicked()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D hitCollider = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));

            if (hitCollider != null && hitCollider.CompareTag("Chest"))
            {
                Debug.Log(hitCollider.name);

                return Clickable.ChestClicked;
            }
            else
            {
                return Clickable.ChestNotClicked;
            }
        }

        return Clickable.DidntClick;
    }
}