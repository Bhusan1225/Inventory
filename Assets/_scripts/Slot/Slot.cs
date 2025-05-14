using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class Slot 
{
    //[SerializeField]
    private Item item;
    [SerializeField]
    public Tool tool;
    [SerializeField]
    private int quantity;
    [SerializeField]
    private int id;

    

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
        GetID();
    }

    public Item GetItem() {  return item; }
    public Tool GetTool() 
    { 
        return tool; 
    }

    public void SetTool(Tool newTool)
    {
        tool = newTool;
    }

    public int GetQuantity() { return quantity; }

    public int GetID() 
    { 
        id =tool.itemID;
        return id;
    }

    public string GetDescription()
    {
        return tool.Description;
    }

    public string GetName()
    {
        return tool.name;
    }

    public void AddQuantity(int _quantity)
    {
        quantity += _quantity;

    }
    
    
    public void SubQuantity(int _quantity) 
    { 
        quantity -= _quantity; 
    
    }

}
