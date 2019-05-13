using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using System.Linq;

public class CommanChest : MonoBehaviour
{
    private Transform parentCanvasTransform;
    private GameObject chestPanel;
    private Transform Player;
    private GameObject characterPanel;

    private SpriteRenderer activeSprite;
    private Sprite closedChest;

    [SerializeField]
    private GameObject pressF;

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
                    activeSprite.sprite = emptyChest;
                }
                else
                {
                    activeSprite.sprite = fullChest;
                }
            }
            else
            {
                activeSprite.sprite = closedChest;
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
        InitializeComponents();
        InitializePanelCanvas();
        GenerateChestItems();
    }

    #region Initialization
    private void InitializeComponents()
    {
        activeSprite = gameObject.GetComponent<SpriteRenderer>();
        parentCanvasTransform = GameObject.Find("InventoryCanvas").transform;
        closedChest = activeSprite.sprite;

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
    }

    private void InitializePanelCanvas()
    {
        var canvas = chestPanel.GetComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceCamera;
        canvas.worldCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        canvas.sortingLayerID = parentCanvasTransform.GetComponent<Canvas>().sortingLayerID;
        canvas.sortingOrder = 5;
        canvas.GetComponent<RectTransform>().anchoredPosition = new Vector2(10, 0);
    }

    private void GenerateChestItems()
    {
        chestPanel.SetActive(false);
        slots = chestPanel.GetComponentsInChildren<ChestSlot>();

        foreach (var item in slots)
        {
            item.AddItem();
        }

        potion = chestPanel.GetComponentInChildren<Potion>();
        potion.Init();
    }
    #endregion

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
        pressF.SetActive(playerInRange);
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