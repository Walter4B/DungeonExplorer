using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsValues : MonoBehaviour
{
    [SerializeField]
    private PlayerStats playerStats;

    public Text armourValue;
    public Text staminaValue;
    public Text strenghtValue;
    public Text IntellectValue;

    public void UpdateStats(List<string> stats)
    {
        armourValue.text = stats[0];
        staminaValue.text = stats[1];
        strenghtValue.text = stats[2];
        IntellectValue.text = stats[3];

        int healthToAdd = int.Parse(staminaValue.text) * 10 - playerStats.Health;
        playerStats.Health = int.Parse(staminaValue.text) * 10;
        playerStats.UpdatePlayerHealth(healthToAdd);
        playerStats.Armor = int.Parse(armourValue.text);
    }
}
