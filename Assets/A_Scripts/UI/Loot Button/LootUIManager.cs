using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootUIManager : MonoBehaviour
{
    [SerializeField] WeaponShopController weaponShop;
    [SerializeField] InventoryController inventory;
    [SerializeField] HeaderUIManager headerUI;

    [SerializeField] WeaponSlot weaponSlot;
    [SerializeField] Item item;
   

    public void LootItemGenerator()
    {
        if (weaponShop.Slot.Count == 0) return; // Safety check

        int randomIndex = Random.Range(0, weaponShop.Slot.Count);
        int randomQuantity = Random.Range(0, 3);
        RandomItemSelect(randomIndex, randomQuantity);
        RandomItemSelect(randomIndex, randomQuantity);
        RandomItemSelect(randomIndex, randomQuantity);

    }


    void RandomItemSelect(int randomIndex, int randomQuantity)
    {
        randomIndex = Random.Range(0, weaponShop.Slot.Count);
        weaponSlot = weaponShop.Slot[randomIndex];
        item = weaponSlot.GetWeapon();
        randomQuantity = Random.Range(0, 3);
        inventory.Add(item, randomQuantity);
        headerUI.DeductGold_Weight(item, randomQuantity);
    }

}
