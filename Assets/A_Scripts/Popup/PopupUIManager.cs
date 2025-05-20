using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TMPro;
using UnityEditor.Tilemaps;
using UnityEditor.VisionOS;
using UnityEngine;
using UnityEngine.UI;

public class PopupUIManager : MonoBehaviour
{
    [SerializeField] private Weapons_Item popUpWeapon;
    [SerializeField] private TextMeshProUGUI popUpQuantity;
    //[SerializeField] private int weaponQuantity; // this will be the original quantity

    [SerializeField] ToolShopController toolShop;
    [SerializeField] int buyingCount;
    [SerializeField] TextMeshProUGUI buyingCountText;

    private void OnEnable()
    {
        buyingCount = 0;
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

            

        }
        else
        {
            Debug.Log("Null, Null, Null, Null");
        }
            
    }
    public void SetPopupData(Weapons_Item weapon, TextMeshProUGUI qtyText)
    {
        this.popUpWeapon = weapon;
        this.popUpQuantity = qtyText;
    }

    public Weapons_Item GetPopUpWeapon()
    {
        return popUpWeapon;
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
