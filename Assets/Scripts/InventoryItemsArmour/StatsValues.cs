using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsValues : MonoBehaviour
{
    [SerializeField]
    private PlayerStats playerStats;

    [SerializeField]
    private TextMeshProUGUI armourValue;
    [SerializeField]
    private TextMeshProUGUI staminaValue;
    [SerializeField]
    private TextMeshProUGUI strenghtValue;
    [SerializeField]
    private TextMeshProUGUI IntellectValue;
    [SerializeField]
    private TextMeshProUGUI healthValue;

    public void UpdateStats(List<string> stats)
    {
        armourValue.text = stats[0];
        staminaValue.text = (int.Parse(stats[1]) - 20).ToString();
        strenghtValue.text = stats[2];
        IntellectValue.text = (int.Parse(stats[3]) - 20).ToString();

        int healthToAdd = int.Parse(stats[1]) * 5 - playerStats.Health;
        playerStats.Health = int.Parse(stats[1]) * 5;
        healthValue.text = playerStats.Health.ToString();
        playerStats.UpdatePlayerHealth(healthToAdd);

        int manaToAdd = int.Parse(stats[3]) * 5 - playerStats.Mana;
        playerStats.Mana = int.Parse(stats[3]) * 5;
        playerStats.UpdatePlayerMana(manaToAdd);

        playerStats.Armor = int.Parse(armourValue.text);
        playerStats.PlayerArmor.text = armourValue.text;

        playerStats.SpellDamage = 10 + int.Parse(IntellectValue.text);
        playerStats.MeleeDamage = 10 + int.Parse(strenghtValue.text);
    }
}
