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

    [SerializeField] private ToolShop toolShop;
    public Tool selectedTool = null ;

    [SerializeField] int buyingCount;
    [SerializeField] TextMeshProUGUI buyingCountText;

    [SerializeField] int quantity;

    //bool isClosed;
   
    public Image GetIconImage()
    {
        return image;
    }

    public Tool GetTool()
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

    public void TransferInfo()
    {
        //Reseting();
        popup.SetActive(true);

        popup.transform.GetChild(0).GetComponent<Image>().sprite = image.sprite; // slot image
        popup.transform.GetChild(1).GetComponent<Text>().text = quantityText.text;// slot Quantity
        popup.transform.GetChild(2).GetComponent<Text>().text = descriptionText.text; // slot description
        popup.transform.GetChild(3).GetComponent<Text>().text = nameText.text; // slot nameText

        findTool();
    }

    public void findTool()
    {
 
        for (int i = 0; i < toolShop.Slot.Count; i++)
        {
            Slot Slot = toolShop.Slot[i]; // we got all slots info one by one here 
            int Quantity = toolShop.Slot[i].GetQuantity();  
            //Debug.Log("Slot Name" + toolShop.Slot[i].GetName());
            if (Slot != null && toolShop.Slot[i].GetName() == popup.transform.GetChild(3).GetComponent<Text>().text)
            {
                selectedTool = toolShop.Slot[i].GetTool();
                quantity = toolShop.Slot[i].GetQuantity();
                //Debug.Log("tool Name" + toolShop.Slot[i].GetName());
                //Debug.Log("tool is " + toolShop.Slot[i].GetTool());
                //Debug.Log("selectedTool is  " + selectedTool);
            }
            
        }
        
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
