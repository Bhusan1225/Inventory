using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;
using UnityEngine.UI;
using Unity.Burst.CompilerServices;

public class ToolShop : Shop
{
    [SerializeField]  List<Slot> tools = new List<Slot>();
    [SerializeField] private GameObject toolslotHolder;

    private GameObject[] slots; // array declare
                                // Public getter for the tools list
    public List<Slot> Slot => tools;
    private void Start()
    {
        
        slots = new GameObject[toolslotHolder.transform.childCount]; // array initialize, where i set size of array
        for (int i = 0; i < toolslotHolder.transform.childCount; i++)
        {
            slots[i] = toolslotHolder.transform.GetChild(i).gameObject;
        }
        RefreshUI();
    }
    public override void DisplayShopType() // no need much
    {
        Debug.Log("Tool Shop");
    }
    public void RefreshUI()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            try
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = true;
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = tools[i].GetTool().itemIcon;
                slots[i].transform.GetChild(1).GetComponent<Text>().text = tools[i].GetQuantity() + "";

                slots[i].transform.GetChild(2).GetComponent<Text>().text = tools[i].GetDescription();
                slots[i].transform.GetChild(3).GetComponent<Text>().text = tools[i].GetName();
               
            }
            catch 
            {
                
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = false;
                slots[i].transform.GetChild(1).GetComponent<Text>().text = "";
                slots[i].transform.GetChild(2).GetComponent<Text>().text = "";
                slots[i].transform.GetChild(3).GetComponent<Text>().text = "";
            }
            
        }
    }
    public void Add(Tool tool)
    {
       
           // tools.Add(tool);
           //check if inventory contains item

        Slot slot = Contains(tool);
        if (slot != null)
        {
            slot.AddQuantity(1);

        }
        else
        {
            tools.Add(new Slot(tool, 1));
        }
        RefreshUI();
    }

    public bool Remove(Tool tool)
    {
        Slot temp = Contains(tool);

        if (temp != null)
        {
            if (temp.GetQuantity() > 1)
            {
                temp.SubQuantity(1);
            }
            else
            {
                Slot slotToRemove = new Slot();
                foreach (Slot slot in tools)
                {
                    if (slot.GetTool() == tool)
                    {
                        slotToRemove = slot;
                        break;
                    }
                }
                tools.Remove(slotToRemove);

            }
        }
        else
        {
            return false;
        }

            RefreshUI();
        return true;
    }

    public Slot Contains(Tool tool)
    {
        foreach (Slot slot in tools)
        {
            if(slot.GetTool() == tool )
            {
                return slot;
            }
        }

        return null;
    }

   
}
