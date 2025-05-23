using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HeaderUIManager : UIManager
{
    [SerializeField] int maxWeight ;
    [SerializeField] int maxGold;

    int weight;
    int gold;
    [SerializeField] TextMeshProUGUI weightText;
    [SerializeField] TextMeshProUGUI goldText;

    void Start()
    {
        weight = maxWeight;
        gold = maxGold;

       
        goldText.text = "Gold: " + gold;
        weightText.text = "Weight: " + weight;
    }

    public void DeductGold_Weight(Consumeable_Item popUpConsumeable, int quatity) // when buying items from Inventory
    {
        
        if (gold >= popUpConsumeable.itemPrice && weight >= popUpConsumeable.itemWeight)
        {
            gold -= quatity * popUpConsumeable.itemPrice;
            weight -= quatity *popUpConsumeable.itemWeight;

            
            goldText.text = "Gold: " + gold;
            weightText.text = "Weight: " + weight;
        }
        else
        {
          
            Debug.LogWarning("You cannot buy this item. Not enough gold or weight capacity.");
        }
    }

    public void DeductGold_Weight(Weapon_Item popUpWeapon, int quatity) // when buying items from Inventory
    {

        if (gold >= popUpWeapon.itemPrice && weight >= popUpWeapon.itemWeight)
        {
            gold -= quatity * popUpWeapon.itemPrice;
            weight -= quatity * popUpWeapon.itemWeight;


            goldText.text = "Gold: " + gold;
            weightText.text = "Weight: " + weight;
        }
        else
        {

            Debug.LogWarning("You cannot buy this item. Not enough gold or weight capacity.");
        }
    }

    void ReduceGoldandWeight()
    { 
    
    }

    void AddGoldandWeight()
    {

    }

    public void DeductGold_Weight(Item popUpItem, int quatity) // when buying items from Inventory
    {

        if (gold >= popUpItem.itemPrice && weight >= popUpItem.itemWeight)
        {
            gold -= quatity * popUpItem.itemPrice;
            weight -= quatity * popUpItem.itemWeight;


            goldText.text = "Gold: " + gold;
            weightText.text = "Weight: " + weight;
        }
        else
        {

            Debug.LogWarning("You cannot buy this item. Not enough gold or weight capacity.");
        }
    }


    public void RestoreGoldAndWeight(Item popUpItem, int quatity) //when selling items from Inventory
    {

        if (quatity > 0 && gold <maxGold && weight < maxWeight)
        {
            gold += quatity *popUpItem.itemPrice;
            weight += quatity * popUpItem.itemWeight;


            goldText.text = "Gold: " + gold;
            weightText.text = "Weight: " + weight;
        }
        else
        {

            Debug.LogWarning("You cannot buy this item. Not enough gold or weight capacity.");
        }
    }


    public void RestoreGoldAndWeight(Consumeable_Item popUpWeapon, int quatity) //when you cancel to buy the items in store

    {

        if (quatity > 0)
        {
            gold += quatity * popUpWeapon.itemPrice;
            weight += quatity * popUpWeapon.itemWeight;


            goldText.text = "Gold: " + gold;
            weightText.text = "Weight: " + weight;
        }
        else
        {

            Debug.LogWarning("nothing in the cart");
        }
    }
}
