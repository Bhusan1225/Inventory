using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using TMPro;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UI;

public class PopupUIManager : MonoBehaviour
{
    public Weapons_Item popUpweapon;
    public Text quantity;
    [SerializeField] private ToolShopController toolShop;

    [SerializeField] int buyingCount;
    [SerializeField] TextMeshProUGUI buyingCountText;
    public void addWeapon()
    {
        if (popUpweapon != null)
        {
            toolShop.Remove(popUpweapon);
            buyingCount++;
            buyingCountText.text = "" + buyingCount;
            //quantity

            Debug.Log("Quantaty "+ quantity.text);

             this.transform.GetChild(1).GetComponent<Text>().text = quantity.text;  
            //quantity = int.Parse(quan);
        }
        else
        {
            Debug.Log("Null, NUll, null,null");
        }
            
        }
    
    

    public void close()
    {
      this.gameObject.SetActive(false);
    }
}
