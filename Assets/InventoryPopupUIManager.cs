using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryPopupUIManager : MonoBehaviour
{
    [SerializeField] protected Item popUpItem;
    [SerializeField] protected TextMeshProUGUI popUpQuantity;

    [SerializeField] WeaponShopController weaponShop;
    [SerializeField] int sellingCount;
    [SerializeField] TextMeshProUGUI sellingCountText;
    [SerializeField] HeaderUIManager headerUI;

    [SerializeField] InventoryController inventoryController;
    public void SetPopupData(Item item, TextMeshProUGUI qtyText)
    {
        this.popUpItem = item;
        this.popUpQuantity = qtyText;
    }


    //public void SetPopupData(Item item, TextMeshProUGUI qtyText)
    //{
    //    this.popUpItem = item;
    //    this.popUpQuantity = qtyText;
    //}
    private void OnEnable()
    {
        resetting();
    }

    public void addWeapon()
    {


        if (popUpItem != null)
        {
            inventoryController.Remove(popUpItem);
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
        inventoryController.Remove(popUpItem, sellingCount);
        resetting();

    }

    public void Cancel()
    {

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

