using UnityEngine;
using UnityEngine.UI;

public class ArmourPiece : ScriptableObject
{
    new public string name = "New item";
    public Sprite icon = null;

    public int ArmourValue { private set; get; }
    public Armour.PossibleArmourSlots ArmourSlot { private set; get; }
    private Armour.ArmourType armourType;
    private Armour.Rarity rarity;

    public int Intellect { private set; get; }
    public int Strength { private set; get; }
    public int Stamina { private set; get; }

    public void Init(int value, Armour.PossibleArmourSlots slotName)
    {
        this.ArmourValue = value;
        this.ArmourSlot = slotName;

        if (value == 0)
        {
            armourType = Armour.ArmourType.Cloth;
        }
        else if ((float) value / (int)slotName < 0.25)
        {
            armourType = Armour.ArmourType.Light;
        }
        else if ((float)value / (int)slotName < 0.75)
        {
            armourType = Armour.ArmourType.Medium;
        }
        else if ((float)value / (int)slotName < 1)
        {
            armourType = Armour.ArmourType.Heavy;
        }

        Strength = RandomNumberGenerator.GetRandom(5);
        Intellect = RandomNumberGenerator.GetRandom(5);
        Stamina = RandomNumberGenerator.GetRandom(5);

        var attributesSum = Strength + Intellect + Stamina;

        if (attributesSum <= 5)
        {
            rarity = Armour.Rarity.Common;
        }
        else if (attributesSum <= 10)
        {
            rarity = Armour.Rarity.Rare;
        }
        else if (attributesSum <= 14)
        {
            rarity = Armour.Rarity.Epic;
        }
        else
        {
            rarity = Armour.Rarity.Legendary;
        }

        name = string.Format("{0:9} {1:8} {2:10}", rarity.ToString(), armourType.ToString(), ArmourSlot.ToString());

        var path = "images/" + ArmourSlot.ToString().ToLower();
        icon = Resources.Load<Sprite>(path);

        if (icon == null)
        {
            Debug.Log(path);
        }
    }

    public string[] Values()
    {
        return new string[] { this.name, this.ArmourValue.ToString(), this.Stamina.ToString(), this.Strength.ToString(), this.Intellect.ToString() };
    }
}
