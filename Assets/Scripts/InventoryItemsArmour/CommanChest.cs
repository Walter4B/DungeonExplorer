using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Linq;

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

    private SpriteRenderer spriteRenderer;

    private Sprite closedChest;

    [SerializeField]
    private Sprite fullChest;
    [SerializeField]
    private Sprite emptyChest;

    private bool ChestActive
    {
        set
        {
            chestPanel.SetActive(value);

            if (value)
            {
                if (slots.Count(slot => slot != null) == 0 && potion == null)
                {
                    spriteRenderer.sprite = emptyChest;
                }
                else
                {
                    spriteRenderer.sprite = fullChest;
                }
            }
            else
            {
                spriteRenderer.sprite = closedChest;
            }
        }
    }

    private readonly float radius = 2.5f;
    private float distance;
    private ChestSlot[] slots;
    private Potion potion;

    private bool playerInRange = false;

    private void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        parentCanvasTransform = GameObject.Find("InventoryCanvas").transform;
        closedChest = spriteRenderer.sprite;

        if (gameObject.name.Contains("Comman"))
        {
            chestPanel = gameObject.transform.Find("CommanChestPanel").gameObject;
        }
        else
        {
            chestPanel = gameObject.transform.Find("BossChestPanel").gameObject;
        }

        Player = GameObject.FindGameObjectWithTag("Player").transform;
        characterPanel = parentCanvasTransform.Find("CharacterPanel").gameObject;

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

        potion = chestPanel.GetComponentInChildren<Potion>();
        potion.Init();
    }

    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        distance = Vector2.Distance(Player.position, transform.position);
        playerInRange = distance < radius;
        UpdateChest();
    }

    private void UpdateChest()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.F))
        {
            if (!chestPanel.activeSelf)
            {
                characterPanel.SetActive(true);
                ChestActive = true;
            }
            else
            {
                ChestActive = false;
            }
        }
        else if (!playerInRange && chestPanel.activeSelf)
        {
            ChestActive = false;
        }
    }
}