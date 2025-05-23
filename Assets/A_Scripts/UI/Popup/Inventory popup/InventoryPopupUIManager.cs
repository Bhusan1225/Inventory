using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryPopupUIManager : MonoBehaviour
{
    [SerializeField] protected Item popUpItem;
    [SerializeField] protected TextMeshProUGUI popUpQuantity;

    [SerializeField] WeaponShopController weaponShop;
    [SerializeField] InventoryController inventory;
    [SerializeField] int sellingCount;
    [SerializeField] TextMeshProUGUI sellingCountText;
    [SerializeField] HeaderUIManager headerUI;

    
    public void SetPopupData(Item item, TextMeshProUGUI qtyText)
    {
        this.popUpItem = item;
        this.popUpQuantity = qtyText;
    }


    
    private void OnEnable()
    {
        resetting();
    }

    public void addWeapon()
    {


        if (popUpItem != null)
        {
            inventory.Remove(popUpItem);
            sellingCount++;
            sellingCountText.text = "" + sellingCount;

            Debug.Log("Quantaty " + popUpQuantity.text);
            this.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = popUpQuantity.text;
            headerUI.RestoreGoldAndWeight(popUpItem, 1);  



        }
        else
        {
            Debug.Log("Null, Null, Null, Null");
        }

    }

    public void SellingItems()
    {
        Debug.Log("Buying Quatity: " + sellingCount);
        Debug.Log("Congrats, you sell the item " + sellingCount);
        inventory.Remove(popUpItem, sellingCount);
        resetting();

    }

    public void CancelSelling()
    {

        inventory.Add(popUpItem, sellingCount);
        headerUI.DeductGold_Weight(popUpItem, sellingCount);
        this.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = popUpQuantity.text;
        resetting();
    }

    
    public void close()
    {
        resetting();
        this.gameObject.SetActive(false);
    }

    private void resetting()
    {
        sellingCount = 0;
        sellingCountText.text = "" + sellingCount;
    }
}

