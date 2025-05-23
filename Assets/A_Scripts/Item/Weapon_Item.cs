using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Item Class", menuName = "Item/Weapon")]
public class Weapon_Item : Item
{

    public override Item GetItem() { return this; }
    public override Weapon_Item GetWeapon() { return this; }
    public override Treasure_Item GetTreasure() { return null; }
    public override Consumeable_Item GetConsumeable() { return null; }

}
