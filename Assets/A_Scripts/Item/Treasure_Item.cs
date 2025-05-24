using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "new Item Class", menuName = "Item/Treasure")]
public class Treasure_Item : Item
{

  
    public override Item GetItem() { return this; }
    public override Weapon_Item GetWeapon() { return null; }
    public override Treasure_Item GetTreasure() { return this; }
    public override Consumeable_Item GetConsumeable() { return null; }
}
