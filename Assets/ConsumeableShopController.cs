using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConsumeableShopController : MonoBehaviour
{
    [SerializeField] List<ConsumeableSlot> consumeableSlot = new List<ConsumeableSlot>();
    [SerializeField] GameObject consumeableSlotHolder;

    private GameObject[] slots;

    public List<ConsumeableSlot> Slot => consumeableSlot;

    private void Start()
    {
        slots = new GameObject[consumeableSlotHolder.transform.childCount];
        for (int i = 0; i < consumeableSlotHolder.transform.childCount; i++)
        {
            slots[i] = consumeableSlotHolder.transform.GetChild(i).gameObject;
        }
        RefreshUI();
    }

    public void RefreshUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            try
            {
                slots[i].GetComponent<SlotManager>().slotConsumeable = consumeableSlot[i].consumeable;
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = true;
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = consumeableSlot[i].GetConsumeable().itemIcon;
                slots[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = consumeableSlot[i].GetQuantity() + "";
                slots[i].transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = consumeableSlot[i].GetDescription();
                slots[i].transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = consumeableSlot[i].GetName();
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

    public void Add(Consumeable_Item consumenable)
    {
        ConsumeableSlot slot = Contains(consumenable);
        if (slot != null)
        {
            slot.AddQuantity(1);
        }
        else
        {
            consumeableSlot.Add(new ConsumeableSlot(consumenable, 1));
        }
        RefreshUI();
    }

    public void Add(Consumeable_Item consumenable, int quantity)
    {
        ConsumeableSlot slot = Contains(consumenable);
        if (slot != null)
        {
            slot.AddQuantity(quantity);
        }
        else
        {
            consumeableSlot.Add(new ConsumeableSlot(consumenable, quantity));
        }
        RefreshUI();
    }

    public bool Remove(Consumeable_Item consumenable)
    {
        ConsumeableSlot temp = Contains(consumenable);

        if (temp != null)
        {
            if (temp.GetQuantity() > 1)
            {
                temp.SubQuantity(1);
            }
            else
            {
                ConsumeableSlot slotToRemove = new ConsumeableSlot();
                foreach (ConsumeableSlot slot in consumeableSlot)
                {
                    if (slot.GetConsumeable() == consumenable)
                    {
                        slotToRemove = slot;
                        break;
                    }
                }
                consumeableSlot.Remove(slotToRemove);
            }
        }
        else
        {
            return false;
        }

        RefreshUI();
        return true;
    }

    public ConsumeableSlot Contains(Consumeable_Item consumenable)
    {
        foreach (ConsumeableSlot slot in consumeableSlot)
        {
            if (slot.GetConsumeable() == consumenable)
            {
                return slot;
            }
        }

        return null;
    }
}
