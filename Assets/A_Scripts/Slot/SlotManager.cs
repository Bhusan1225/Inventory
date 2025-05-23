using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SlotManager : MonoBehaviour
{
    public Item slotItem = null;
    public Weapon_Item slotWeapon = null;
    public Consumeable_Item slotConsumeable = null;
    public GameObject weaponPopupPanel;
    public GameObject inventoryPopupPanel;
    public GameObject consumeablePopupPanel;

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
            weaponPopupPanel.SetActive(true);
            weaponPopupPanel.GetComponent<PopupUIManager>().SetPopupData(slotWeapon, this.transform.GetChild(1).GetComponent<TextMeshProUGUI>());
            weaponPopupPanel.transform.GetChild(0).GetComponent<Image>().sprite = slotWeapon.itemIcon;
            weaponPopupPanel.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = slotWeapon.description;
            weaponPopupPanel.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = slotWeapon.itemName;
        }
        else if (slotConsumeable != null)
        {
            consumeablePopupPanel.SetActive(true);
            consumeablePopupPanel.GetComponent<ConsumeablePopupPanel>().SetPopupData(slotConsumeable, this.transform.GetChild(1).GetComponent<TextMeshProUGUI>());
            consumeablePopupPanel.transform.GetChild(0).GetComponent<Image>().sprite = slotConsumeable.itemIcon;
            consumeablePopupPanel.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = slotConsumeable.description;
            consumeablePopupPanel.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = slotConsumeable.itemName;
        }



    }

    public void PressButton()
    {
        Debug.LogError("The button is working");
    }
}
