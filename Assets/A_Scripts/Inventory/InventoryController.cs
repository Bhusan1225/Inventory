using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public List<ItemSlot> itemSlot = new List<ItemSlot>();
    public GameObject itemSlotHolder;

    private GameObject[] slots; // array declare

    //public List<WeaponSlot> Slot => itemSlot;
    private void Start()
    {

        slots = new GameObject[itemSlotHolder.transform.childCount]; // array initialize, where i set size of array
        for (int i = 0; i < itemSlotHolder.transform.childCount; i++)
        {
            slots[i] = itemSlotHolder.transform.GetChild(i).gameObject;
        }
        RefreshUI();
    }

    public void RefreshUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            try
            {
                //slots[i].GetComponent<SlotManager>().slotWeapon = itemSlot[i].GetItem();
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = true;
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = itemSlot[i].GetIcon();
                slots[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = itemSlot[i].GetQuantity() + "";

                slots[i].transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = itemSlot[i].GetDescription();
                slots[i].transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = itemSlot[i].GetName();

            }
            catch
            {

                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = false;
                slots[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "";
                slots[i].transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "";
                slots[i].transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = "";
            }

        }
    }

    public void Add(Item item, int quantity)
    {
        // itemSlot.Add(itemSlot);
        //check if inventory contains item

        ItemSlot slot = Contains(item);
        if (slot != null)
        {
            Debug.Log("Add slot is not Null");
            slot.AddQuantity(quantity);

        }
        else
        {
            Debug.Log("Add slot is Null,Null, Null");
            itemSlot.Add(new ItemSlot(item, quantity));
        }
        RefreshUI();
    }

    public bool Remove(Item item, int quantity)
    {
       ItemSlot temp = Contains(item);

        if (temp != null)
        {
            if (temp.GetQuantity() > 1)
            {
                temp.SubQuantity(quantity);
            }
            else
            {
                ItemSlot slotToRemove = new ItemSlot();
                foreach (ItemSlot slot in itemSlot)
                {
                    if (slot.GetItem() == item)
                    {
                        slotToRemove = slot;
                        break;
                    }
                }
                itemSlot.Remove(slotToRemove);

            }
        }
        else
        {
            return false;
        }

        RefreshUI();
        return true;
    }

  


    public ItemSlot Contains(Item item)
    {
        foreach (ItemSlot slot in itemSlot)
        {
            if (slot.GetItem() == item)
            {
                return slot;
            }
        }

        return null;
    }


}
