using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class TreasureItemSlot 
{
    private Item item;
    [SerializeField] public Treasure_Item treasureItem;
    int weaponQuantity;
    int quantity;
    private Sprite weaponIcon;
    private bool isInitialized = false;



    public TreasureItemSlot()
    {
        item = null;
        treasureItem = null;
        if (treasureItem != null)
        {
            treasureItem.itemQuantity = weaponQuantity;
        }

    }
    public TreasureItemSlot(Item _item, int _quantity)
    {
        weaponQuantity = treasureItem.itemQuantity;
        item = _item;
        quantity = _quantity;
    }

    public TreasureItemSlot(Treasure_Item _tool, int _quantity)
    {
        weaponQuantity = treasureItem.itemQuantity;
        treasureItem = _tool;
        quantity = _quantity;
    }

    public Sprite GetIcon() => treasureItem.itemIcon;
    public Treasure_Item GetTreasureItem() => treasureItem;
    public int GetQuantity()
    {
        if (!isInitialized)
        {
            weaponQuantity = treasureItem.itemQuantity;
            isInitialized = true;
        }

        return weaponQuantity;
    }
    public string GetDescription() => treasureItem != null ? treasureItem.description : string.Empty;
    public string GetName() => treasureItem != null ? treasureItem.name : string.Empty;

    public void AddQuantity(int _quantity) => weaponQuantity += _quantity;
    public void SubQuantity(int _quantity) => weaponQuantity -= _quantity;

    //public int GetID() => slotWeapon != null ? slotWeapon.itemID : -1;
    //public void SetTool(Consumeable_Item newTool) => slotWeapon = newTool;
    //public Item GetItem() => item;

}
