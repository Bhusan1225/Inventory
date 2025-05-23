using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;
using UnityEngine.UI;
using Unity.Burst.CompilerServices;
using TMPro;

public class WeaponShopController : MonoBehaviour
{
    [SerializeField]  List<WeaponSlot> weaponSlot = new List<WeaponSlot>();
    [SerializeField]  GameObject weaponSlotHolder;

    private GameObject[] slots; // array declare
                               
    public List<WeaponSlot> Slot => weaponSlot;
    private void Start()
    {
        
        slots = new GameObject[weaponSlotHolder.transform.childCount]; // array initialize, where i set size of array
        for (int i = 0; i < weaponSlotHolder.transform.childCount; i++)
        {
            slots[i] = weaponSlotHolder.transform.GetChild(i).gameObject;
        }
        RefreshUI();
    }
  
    public void RefreshUI()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            try
            {
                slots[i].GetComponent<SlotManager>().slotWeapon = weaponSlot[i].weapon;
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = true;
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = weaponSlot[i].GetWeapon().itemIcon;
                slots[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = weaponSlot[i].GetQuantity() + "";

                slots[i].transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = weaponSlot[i].GetDescription();
                slots[i].transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = weaponSlot[i].GetName();
               
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
   
    public void Add(Weapon_Item weapon)
    {
       
           // itemSlot.Add(itemSlot);
           //check if inventory contains item

        WeaponSlot slot = Contains(weapon);
        if (slot != null)
        {
            slot.AddQuantity(1);

        }
        else
        {
            weaponSlot.Add(new WeaponSlot(weapon, 1));
        }
        RefreshUI();
    }

    public void Add(Weapon_Item weapon, int quantity)
    {

        // itemSlot.Add(itemSlot);
        //check if inventory contains item

        WeaponSlot slot = Contains(weapon);
        if (slot != null)
        {
            slot.AddQuantity(quantity);

        }
        else
        {
            weaponSlot.Add(new WeaponSlot(weapon, quantity));
        }
        RefreshUI();
    }

    public bool Remove(Weapon_Item weapon)
    {
        WeaponSlot temp = Contains(weapon);

        if (temp != null)
        {
            if (temp.GetQuantity() > 1)
            {
                temp.SubQuantity(1);
            }
            else
            {
                WeaponSlot slotToRemove = new WeaponSlot();
                foreach (WeaponSlot slot in weaponSlot)
                {
                    if (slot.GetWeapon() == weapon)
                    {
                        slotToRemove = slot;
                        break;
                    }
                }
                weaponSlot.Remove(slotToRemove);

            }
        }
        else
        {
            return false;
        }

        RefreshUI();
        return true;
    }

      public WeaponSlot Contains(Weapon_Item weapon)
    {
        foreach (WeaponSlot slot in weaponSlot)
        {
            if(slot.GetWeapon() == weapon )
            {
                return slot;
            }
        }

        return null;
    }

   
}
