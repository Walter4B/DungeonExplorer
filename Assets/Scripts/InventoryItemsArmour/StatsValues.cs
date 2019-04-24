using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsValues : MonoBehaviour
{
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
    }
}
