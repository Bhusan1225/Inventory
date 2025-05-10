using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Tool Class", menuName = "Item/Consumable")]
public class Consumeable : Item
{
    [Header("Consumable")]
    public float healthAdded;

    public override Item GetItem() { return this; }
    public override Tool GetTool() { return null; }
    public override Misc GetMisc() { return null; }
    public override Consumeable GetConsumeable() { return this; }
}
