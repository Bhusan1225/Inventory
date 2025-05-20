using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new item Class", menuName = "Item/Consumable")]
public class Consumeable_Item : Item
{
    [Header("Consumable")]
    public float healthAdded;

    public override Item GetItem() { return this; }
    public override Weapons_Item GetTool() { return null; }
    public override Treasure_Item GetTreasure() { return null; }
    public override Consumeable_Item GetConsumeable() { return this; }
}
