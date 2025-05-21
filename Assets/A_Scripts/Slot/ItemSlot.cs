using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemSlot
{
    [SerializeField]
    public Item item;
    //[SerializeField] public Weapons_Item weapon;
    int itemQuantity;
    int quantity;
    //private Sprite itemIcon;
   // private bool isInitialized = false;



    public ItemSlot()
    {
        item = null;
        
        if (item != null)
        {
            item.itemQuantity = itemQuantity;
        }

    }

    public ItemSlot(Item _item, int _quantity)
    {
        
        item = _item;
        quantity = _quantity;
        //itemQuantity = item.itemQuantity;
      
    }

    //public ItemSlot(Weapons_Item _tool, int _quantity)
    //{
    //    itemQuantity = weapon.itemQuantity;
    //    weapon = _tool;
    //    quantity = _quantity;
    //}

    public Sprite GetIcon() => item.itemIcon;
   //public Weapons_Item GetWeapon() => weapon;
    public int GetQuantity()
    {
        //if (!isInitialized)
        //{
        //    itemQuantity = item.itemQuantity;
        //    isInitialized = true;
        //}

        return quantity;
    }
    public string GetDescription() => item != null ? item.description : string.Empty;
    public string GetName() => item != null ? item.name : string.Empty;

    public void AddQuantity(int _quantity) => quantity += _quantity;
    public void SubQuantity(int _quantity) => quantity -= _quantity;

    //public int GetID() => slotWeapon != null ? slotWeapon.itemID : -1;
    //public void SetTool(Weapons_Item newTool) => slotWeapon = newTool;
    public Item GetItem() => item;
}
