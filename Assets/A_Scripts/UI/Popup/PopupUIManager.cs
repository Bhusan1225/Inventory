using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TMPro;
using UnityEditor.Tilemaps;
using UnityEditor.VisionOS;
using UnityEngine;
using UnityEngine.UI;

public class PopupUIManager : UIManager
{

    [SerializeField] protected Weapons_Item popUpWeapon;
    [SerializeField] protected TextMeshProUGUI popUpQuantity;

    [SerializeField] ToolShopController toolShop;
    [SerializeField] int buyingCount;
    [SerializeField] TextMeshProUGUI buyingCountText;
    [SerializeField] HeaderUIManager headerUI;

    [SerializeField] InventoryController inventoryController;
    public void SetPopupData(Weapons_Item weapon, TextMeshProUGUI qtyText)
    {
        this.popUpWeapon = weapon;
        this.popUpQuantity = qtyText;
    }
    private void OnEnable()
    {
        buyingCount = 0;
        //headerUI = GetComponent<HeaderUIManager>(); ;
    }

    public void addWeapon()
    {
        
        
        if (popUpWeapon != null )
        {
            toolShop.Remove(popUpWeapon);
            buyingCount++;
            buyingCountText.text = "" + buyingCount;

            Debug.Log("Quantaty "+ popUpQuantity.text);
            this.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = popUpQuantity.text;
            headerUI.DeductGold_Weight(popUpWeapon);



        }
        else
        {
            Debug.Log("Null, Null, Null, Null");
        }
            
    }
    
    public void BuyingItems()
    {
        Debug.Log("Buying Quatity: " + buyingCount);
        inventoryController.Add(popUpWeapon, buyingCount);
        resetting();

    }

    public void close()
    {
      resetting();
      this.gameObject.SetActive(false);
    }

    private void resetting()
    {
        buyingCount = 0;
    }
}
