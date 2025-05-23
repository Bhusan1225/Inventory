using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class ConsumeableSlot 
{
    private Item item;
    [SerializeField] public Consumeable_Item consumeable;
    int consumeableQuantity;
    int quantity;
    private Sprite consumeableIcon;
    private bool isInitialized = false;



    public ConsumeableSlot()
    {
        item = null;
        consumeable = null;
        if (consumeable != null)
        {
            consumeable.itemQuantity = consumeableQuantity;
        }

    }

    public ConsumeableSlot(Item _item, int _quantity)
    {
        consumeableQuantity = consumeable.itemQuantity;
        item = _item;
        quantity = _quantity;
    }

    public ConsumeableSlot(Consumeable_Item _consumeable, int _quantity)
    {
        consumeableQuantity = consumeable.itemQuantity;
        consumeable = _consumeable;
        quantity = _quantity;
    }

    public Sprite GetIcon() => consumeableIcon;
    public Consumeable_Item GetConsumeable() => consumeable;
    public int GetQuantity()
    {
        if (!isInitialized)
        {
            consumeableQuantity = consumeable.itemQuantity;
            isInitialized = true;
        }

        return consumeableQuantity;
    }
    public string GetDescription() => consumeable != null ? consumeable.description : string.Empty;
    public string GetName() => consumeable != null ? consumeable.name : string.Empty;

    public void AddQuantity(int _quantity) => consumeableQuantity += _quantity;
    public void SubQuantity(int _quantity) => consumeableQuantity -= _quantity;

    //public int GetID() => slotWeapon != null ? slotWeapon.itemID : -1;
    //public void SetTool(Consumeable_Item newTool) => slotWeapon = newTool;
    //public Item GetItem() => item;









}
