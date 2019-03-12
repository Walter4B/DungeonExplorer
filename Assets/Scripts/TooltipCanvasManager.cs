using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TooltipCanvasManager : MonoBehaviour
{
    public static TooltipCanvasManager Instance;

    public Transform TooltipPanel;
    public Text ItemNameText;
    public Text ValueText;

    //ovo je u pixelima - paziti zbog razlicitih rezolucija
    public Vector3 PositionOffset;

    private void Awake()
    {
        Instance = this;

        DisableTooltip();
    }

    private void Update()
    {
        TooltipPanel.position = Input.mousePosition + PositionOffset;
    }

    public void DisableTooltip()
    {
        TooltipPanel.gameObject.SetActive(false);

        ItemNameText.text = "";
        ValueText.text = "";
    }

    public void EnableTooltip(Item item)
    {
        if (item == null)
            return;

        ItemNameText.text = item.name;
        ValueText.text = item.Value.ToString();

        TooltipPanel.gameObject.SetActive(true);
    }
}
