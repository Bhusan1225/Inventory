using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SlotManager : MonoBehaviour
{
    public Weapons_Item slotWeapon;
    public GameObject popupPanel;
    //public GameObject UIManager;

    public void transforDataToPopup()
    {
       
        popupPanel.SetActive(true);
        popupPanel.GetComponent<PopupUIManager>().SetPopupData(slotWeapon, this.transform.GetChild(1).GetComponent<TextMeshProUGUI>());
        popupPanel.transform.GetChild(0).GetComponent<Image>().sprite = slotWeapon.itemIcon;
        // popupPanel.GetComponent<PopupUIManager>().popUpQuantity = slotWeapon.itemQuantity;
        //popupPanel.GetComponent<PopupUIManager>().popUpQuantity = this.transform.GetChild(1).GetComponent<Text>();
        popupPanel.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = slotWeapon.description;
        popupPanel.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = slotWeapon.itemName;
    }
}
