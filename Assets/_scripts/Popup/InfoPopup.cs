using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InfoPopup : MonoBehaviour
{
    [SerializeField] private GameObject popup;

    private Image image;
    private Text quantityText;
    private Text descriptionText;
    private Text nameText;

    [SerializeField] private ToolShopController toolShop;
    public Weapons_Item selectedTool = null ;

    [SerializeField] int buyingCount;
    [SerializeField] TextMeshProUGUI buyingCountText;

    [SerializeField] int quantity;

    //bool isClosed;
   
    public Image GetIconImage()
    {
        return image;
    }

    public Weapons_Item GetTool()
    {
        return selectedTool;
    }

    private void Start()
    {
        image = transform.GetChild(0).GetComponent<Image>();
        quantityText = transform.GetChild(1).GetComponent<Text>();
        descriptionText = transform.GetChild(2).GetComponent<Text>();
        nameText = transform.GetChild(3).GetComponent<Text>();
       //findTool();


    }




    //public void AddToCart()
    //{

    //    if (selectedTool != null)
    //    {
    //        toolShop.Remove(selectedTool);
    //        buyingCount++;
    //        buyingCountText.text = "" + buyingCount;


    //    }
    //    else
    //    {
    //        Debug.Log("Null, NUll, null,null");
    //    }
    //}
    public void ClosePopup()
    {
        popup.SetActive(false);
        //Reseting();
    }
    private void Reseting()
    {
        selectedTool = null; // Reset in case it's reused
        buyingCount = 0;
       // isClosed = true;
    }

    
}
