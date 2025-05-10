using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Slot 
{
    //[SerializeField]
    private Item item;
    [SerializeField]
    private Tool tool;
    [SerializeField]
    private int quantity;

    public Slot()
    {
        this.tool = null;
        this.item = null;
        this.quantity = 0;
        // this.tool = _tool;
    }
    public Slot(Item _item, int _quantity)
    {
        this.item = _item;
        this.quantity = _quantity;
       // this.tool = _tool;
    }

    public Slot(Tool _tool, int _quantity)
    {
        this.tool = _tool;
        this.quantity = _quantity;
        // this.tool = _tool;
    }

    public Item GetItem() {  return item; }
    public Item GetTool() { return tool; }

    public int GetQuantity() { return quantity; }
    public void AddQuantity(int _quantity) { quantity += _quantity; }
    public void SubQuantity(int _quantity) { quantity -= _quantity; }

}
