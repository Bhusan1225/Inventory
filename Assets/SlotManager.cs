using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SlotManager : MonoBehaviour
{
    public Weapons_Item slotWeapon;
    public GameObject popupPanel;

    public void transforDataToPopup()
    {
    
        popupPanel.SetActive(true);
        popupPanel.GetComponent<PopupUIManager>().popUpweapon = slotWeapon;
        popupPanel.transform.GetChild(0).GetComponent<Image>().sprite = slotWeapon.itemIcon;
        // popupPanel.GetComponent<PopupUIManager>().quantity = slotWeapon.itemQuantity;
        popupPanel.GetComponent<PopupUIManager>().quantity = this.transform.GetChild(1).GetComponent<Text>();
        popupPanel.transform.GetChild(2).GetComponent<Text>().text = slotWeapon.description;
        popupPanel.transform.GetChild(3).GetComponent<Text>().text = slotWeapon.itemName;
    }
}
