using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HeaderUIManager : UIManager
{
    int maxWeight;
    int maxGold;

    [SerializeField] TextMeshProUGUI weightText;
    [SerializeField] TextMeshProUGUI goldText;

    void Start()
    {
        maxGold = 200;
        maxWeight = 100;

       
        goldText.text = "Gold: " + maxGold;
        weightText.text = "Weight: " + maxWeight;
    }

    public void DeductGold_Weight(Weapons_Item popUpWeapon)
    {
        
        if (maxGold >= popUpWeapon.itemPrice && maxWeight >= popUpWeapon.itemWeight)
        {
            maxGold -= popUpWeapon.itemPrice;
            maxWeight -= popUpWeapon.itemWeight;

            
            goldText.text = "Gold: " + maxGold;
            weightText.text = "Weight: " + maxWeight;
        }
        else
        {
          
            Debug.LogWarning("You cannot buy this item. Not enough gold or weight capacity.");
        }
    }
}
