using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item :ScriptableObject
{
    [Header("Item")]
    public int itemID;
    public string itemName;
    public Sprite itemIcon;

    public string Description;

    public abstract Item GetItem();
    public abstract Tool GetTool();
    public abstract Misc GetMisc();
    public abstract Consumeable GetConsumeable(); 
}
