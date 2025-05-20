using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item :ScriptableObject
{
    [Header("Item")]
    public int itemID;
    public int itemQuantity;
    public string itemName;
    public Sprite itemIcon;

    public int itemWeight;
    public int itemPrice; // in goldCoins


    public string description;

    public abstract Item GetItem();
    public abstract Weapons_Item GetTool();
    public abstract Treasure_Item GetTreasure();
    public abstract Consumeable_Item GetConsumeable(); 
}
