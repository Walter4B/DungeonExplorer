using UnityEngine;
using UnityEngine.UI;

public class PanelValues : MonoBehaviour
{
    public Image image;
    new public Text name;
    public Text armourValue;
    public Text staminaValue;
    public Text strenghtValue;
    public Text IntellectValue;

    public void UpdateValues(ArmourPiece item)
    {
        if (item != null)
        {
            var values = item.Values();
            name.text = values[0];
            armourValue.text = values[1];
            staminaValue.text = values[2];
            strenghtValue.text = values[3];
            IntellectValue.text = values[4];

            if (item.icon != null)
            {
                image.sprite = item.icon;
            }
        }
    }
}
