using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class Armour
{
    public enum PossibleArmourSlots { Head, Shoulders, Chest, Hands, Legs, Boots}
    public enum ArmourType { Cloth, Light, Medium, Heavy}
    public enum Rarity { Common, Rare, Epic, Legendary}

    public static int GetArmourValue(PossibleArmourSlots slot)
    {
        switch (slot)
        {
            case PossibleArmourSlots.Head:
                return 5;
            case PossibleArmourSlots.Shoulders:
                return 6;
            case PossibleArmourSlots.Chest:
                return 20;
            case PossibleArmourSlots.Hands:
                return 5;
            case PossibleArmourSlots.Legs:
                return 10;
            case PossibleArmourSlots.Boots:
                return 5;
        }

        return 0;
    }

    public static int GetSlotIndex(PossibleArmourSlots slot)
    {
        var slots = Enum.GetNames(typeof(PossibleArmourSlots)).ToList();
        return slots.IndexOf(slot.ToString());
    }

    public static PossibleArmourSlots GetArmour()
    {
        var slotList = Enum.GetNames(typeof(PossibleArmourSlots)).ToList();
        slotList.Reverse();

        return (PossibleArmourSlots)Enum.Parse(typeof(PossibleArmourSlots), slotList[RandomNumberGenerator.GetRandom(6)]);
    }
}