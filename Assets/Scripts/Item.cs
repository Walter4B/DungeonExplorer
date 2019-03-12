using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public Sprite Icon;
    public int Value = 0;
    public int Armour = 0;

    public void Use()
    {
        Debug.Log("Item used: " + name);
    }
}
