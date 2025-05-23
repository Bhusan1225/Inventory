using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ConsumeablePopupPanel : MonoBehaviour
{
    [SerializeField] protected Consumeable_Item popUpConsumeable;
    [SerializeField] protected TextMeshProUGUI popUpQuantity;
    [SerializeField] ConsumeableShopController consumeable;
    [SerializeField] int buyingCount;
    [SerializeField] TextMeshProUGUI buyingCountText;
    [SerializeField] HeaderUIManager headerUI;
    [SerializeField] InventoryController inventoryController;

    public void SetPopupData(Consumeable_Item consumeable, TextMeshProUGUI qtyText)
    {
        this.popUpConsumeable = consumeable;
        this.popUpQuantity = qtyText;
    }


     private void OnEnable()
    {
        buyingCount = 0;
        buyingCountText.text = "" + buyingCount;
    }

    public void addConsumeable()
    {


        if (popUpConsumeable != null)
        {
            consumeable.Remove(popUpConsumeable);
            buyingCount++;
            buyingCountText.text = "" + buyingCount;

            Debug.Log("Quantaty " + popUpQuantity.text);
            this.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = popUpQuantity.text;
            headerUI.DeductGold_Weight(popUpConsumeable, 1);



        }
        else
        {
            Debug.Log("Null, Null, Null, Null");
        }

    }

    public void BuyingItems()
    {
        Debug.Log("Buying Quatity: " + buyingCount);
        inventoryController.Add(popUpConsumeable, buyingCount);
        resetting();

    }

    public void CancelBuying()
    {
        consumeable.Add(popUpConsumeable, buyingCount);
        headerUI.RestoreGoldAndWeight(popUpConsumeable, buyingCount);
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
