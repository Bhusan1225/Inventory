using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "new Tool Class", menuName = "Item/Misc")]
public class Treasure_Item : Item
{

    //[Header("Treasure_Item")]


    public override Item GetItem() { return this; }
    public override Weapons_Item GetTool() { return null; }
    public override Treasure_Item GetTreasure() { return this; }
    public override Consumeable_Item GetConsumeable() { return null; }
}
