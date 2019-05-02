using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class CommanChest : MonoBehaviour
{
 //   [SerializeField]
    private Transform parentCanvasTransform;
  //  [SerializeField]
    private GameObject chestPanel;
  //  [SerializeField]
    private Transform Player;
   // [SerializeField]
    private GameObject characterPanel;

    private readonly float radius = 2.5f;
    private float distance;
    private enum Clickable { ChestClicked, ChestNotClicked, DidntClick }

    private ChestSlot[] slots;

    private void Awake()
    {
        parentCanvasTransform = GameObject.Find("InventoryCanvas").transform;

        chestPanel = gameObject.transform.Find(gameObject.name + "Panel").gameObject;
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        characterPanel = parentCanvasTransform.Find("CharacterPanel").gameObject;

        ////chestPanel.transform.SetParent(parentCanvasTransform);
        var canvas = chestPanel.GetComponent<Canvas>();

        canvas.renderMode = RenderMode.ScreenSpaceCamera;
        canvas.worldCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        canvas.sortingLayerID = parentCanvasTransform.GetComponent<Canvas>().sortingLayerID;
        canvas.sortingOrder = 5;

        canvas.GetComponent<RectTransform>().anchoredPosition = new Vector2(10,0);


        chestPanel.SetActive(false);
        slots = chestPanel.GetComponentsInChildren<ChestSlot>();

        foreach (var item in slots)
        {
            item.AddItem();
        }

        chestPanel.GetComponentInChildren<Potion>().Init();
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
            chestPanel.SetActive(!chestPanel.activeSelf);
        }

        if (chestPanel.activeSelf && (distance > radius || CheckIfClicked() == Clickable.ChestNotClicked))
        {
            chestPanel.SetActive(false);
        }
    }


    private Clickable CheckIfClicked()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D hitCollider = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));

            if (hitCollider != null && hitCollider.CompareTag("Chest"))
            {
                if (!chestPanel.activeSelf)
                {
                    characterPanel.SetActive(true);
                }

                return Clickable.ChestClicked;
            }
            else
            {
                return Clickable.ChestNotClicked;
            }
        }

        return Clickable.DidntClick;
    }

    public void DestroyClone()
    {
        chestPanel.transform.SetParent(this.transform);
    }
}