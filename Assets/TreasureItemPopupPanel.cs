using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TreasureItemPopupPanel : MonoBehaviour
{
    [SerializeField] protected Treasure_Item popUpTreasure;
    [SerializeField] protected TextMeshProUGUI popUpQuantity;
    [SerializeField] TreasureShopController treasureShop;
    [SerializeField] int buyingCount;
    [SerializeField] TextMeshProUGUI buyingCountText;
    [SerializeField] HeaderUIManager headerUI;
    [SerializeField] InventoryController inventoryController;

    public void SetPopupData(Treasure_Item consumeable, TextMeshProUGUI qtyText)
    {
        this.popUpTreasure = consumeable;
        this.popUpQuantity = qtyText;
    }


    private void OnEnable()
    {
        buyingCount = 0;
        buyingCountText.text = "" + buyingCount;
    }

    public void addTreasure()
    {

        if (popUpTreasure != null)
        {
            treasureShop.Remove(popUpTreasure);
            buyingCount++;
            buyingCountText.text = "" + buyingCount;

            Debug.Log("Quantaty " + popUpQuantity.text);
            this.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = popUpQuantity.text;
            headerUI.DeductGold_Weight(popUpTreasure, 1);

        }
        else
        {
            Debug.Log("Null, Null, Null, Null");
        }

    }

    public void BuyingItems()
    {
        Debug.Log("Buying Quatity: " + buyingCount);
        inventoryController.Add(popUpTreasure, buyingCount);
        resetting();

    }

    public void CancelBuying()
    {
        treasureShop.Add(popUpTreasure, buyingCount);
        headerUI.RestoreGoldAndWeight(popUpTreasure, buyingCount);
        this.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = popUpQuantity.text;
        resetting();
    }
    public void closePopup()
    {
        resetting();
        this.gameObject.SetActive(false);
    }

    private void resetting()
    {
        buyingCount = 0;
        buyingCountText.text = "" + buyingCount;
    }
}

