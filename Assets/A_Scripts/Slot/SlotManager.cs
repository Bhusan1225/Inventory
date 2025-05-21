using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SlotManager : MonoBehaviour
{
    public Item slotItem = null;
    public Weapons_Item slotWeapon = null;
    public GameObject shopPopupPanel;
    public GameObject inventoryPopupPanel;

    public void transforDataToPopup()
    {


        if (slotItem != null) 
        {
            inventoryPopupPanel.SetActive(true); 
            inventoryPopupPanel.GetComponent<InventoryPopupUIManager>().SetPopupData(slotItem, this.transform.GetChild(1).GetComponent<TextMeshProUGUI>());
            inventoryPopupPanel.transform.GetChild(0).GetComponent<Image>().sprite = slotItem.itemIcon;
            inventoryPopupPanel.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = slotItem.description;
            inventoryPopupPanel.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = slotItem.itemName;
        }
        else if (slotWeapon != null) 
        {
            shopPopupPanel.SetActive(true);
            shopPopupPanel.GetComponent<PopupUIManager>().SetPopupData(slotWeapon, this.transform.GetChild(1).GetComponent<TextMeshProUGUI>());
            shopPopupPanel.transform.GetChild(0).GetComponent<Image>().sprite = slotWeapon.itemIcon;
            shopPopupPanel.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = slotWeapon.description;
            shopPopupPanel.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = slotWeapon.itemName;
        }

        
       
    }

    public void PressButton()
    {
        Debug.LogError("The button is working");
    }
}
