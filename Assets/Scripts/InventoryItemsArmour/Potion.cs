using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Potion : MonoBehaviour
{
    [SerializeField]
    private PlayerStats player;
    [SerializeField]
    private Image image;
    [SerializeField]
    private TextMeshProUGUI potionName;

    public void Init()
    {
        int rnd = RandomNumberGenerator.GetRandom(99) + 1;

        if (rnd % 2 == 0)
        {
            potionName.text = "Mana Potion";
            var path = "images/mana";
            image.sprite = Resources.Load<Sprite>(path);
        }
        else
        {
            potionName.text = "Health Potion";
            var path = "images/health";
            image.sprite = Resources.Load<Sprite>(path);
        }
    }

    public void AddPotion()
    {
        if (potionName.text.Contains("Mana"))
        {
            player.ManaPotions++;
            player.NumOfManaPotions.text = player.ManaPotions.ToString();
        }
        else
        {
            player.HealthPotions++;
            player.NumOfHealthPotions.text = player.HealthPotions.ToString();
        }

        Object.Destroy(this.gameObject);
    }

}
