using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class TreasureShopController : MonoBehaviour
{

    [SerializeField] List<TreasureItemSlot> treasureItemSlot = new List<TreasureItemSlot>();
    [SerializeField] GameObject treasureItemSlotHolder;

    private GameObject[] slots;

    public List<TreasureItemSlot> Slot => treasureItemSlot;

    private void Start()
    {
        slots = new GameObject[treasureItemSlotHolder.transform.childCount];
        for (int i = 0; i < treasureItemSlotHolder.transform.childCount; i++)
        {
            slots[i] = treasureItemSlotHolder.transform.GetChild(i).gameObject;
        }
        RefreshUI();
    }

    public void RefreshUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            try
            {
                slots[i].GetComponent<SlotManager>().slotTreasureItem = treasureItemSlot[i].GetTreasureItem();
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = true;
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = treasureItemSlot[i].GetTreasureItem().itemIcon;
                slots[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = treasureItemSlot[i].GetQuantity() + "";
                slots[i].transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = treasureItemSlot[i].GetDescription();
                slots[i].transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = treasureItemSlot[i].GetName();
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

    public void Add(Treasure_Item consumenable)
    {
        TreasureItemSlot slot = Contains(consumenable);
        if (slot != null)
        {
            slot.AddQuantity(1);
        }
        else
        {
            treasureItemSlot.Add(new TreasureItemSlot(consumenable, 1));
        }
        RefreshUI();
    }

    public void Add(Treasure_Item consumenable, int quantity)
    {
        TreasureItemSlot slot = Contains(consumenable);
        if (slot != null)
        {
            slot.AddQuantity(quantity);
        }
        else
        {
            treasureItemSlot.Add(new TreasureItemSlot(consumenable, quantity));
        }
        RefreshUI();
    }

    public bool Remove(Treasure_Item treasureItem)
    {
        TreasureItemSlot temp = Contains(treasureItem);

        if (temp != null)
        {
            if (temp.GetQuantity() > 1)
            {
                temp.SubQuantity(1);
            }
            else
            {
                TreasureItemSlot slotToRemove = new TreasureItemSlot();
                foreach (TreasureItemSlot slot in treasureItemSlot)
                {
                    if (slot.GetTreasureItem() == treasureItem)
                    {
                        slotToRemove = slot;
                        break;
                    }
                }
                treasureItemSlot.Remove(slotToRemove);
            }
        }
        else
        {
            return false;
        }

        RefreshUI();
        return true;
    }

    public TreasureItemSlot Contains(Treasure_Item TreasureItem)
    {
        foreach (TreasureItemSlot slot in treasureItemSlot)
        {
            if (slot.GetTreasureItem() == TreasureItem)
            {
                return slot;
            }
        }

        return null;
    }
}
