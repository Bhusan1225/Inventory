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
    public Tool selectedTool = null;

    [SerializeField] int buyingCount;
    [SerializeField] TextMeshProUGUI buyingCountText;

   

    

    private void Start()
    {
        image = transform.GetChild(0).GetComponent<Image>();
        quantityText = transform.GetChild(1).GetComponent<Text>();
        descriptionText = transform.GetChild(2).GetComponent<Text>();
        nameText = transform.GetChild(3).GetComponent<Text>();
       //findmySo();


    }

    public void TransferInfo()
    {
        popup.SetActive(false);
        popup.SetActive(true);

        popup.transform.GetChild(0).GetComponent<Image>().sprite = image.sprite; // slot image
        popup.transform.GetChild(1).GetComponent<Text>().text = quantityText.text;// slot Quantity
        popup.transform.GetChild(2).GetComponent<Text>().text = descriptionText.text; // slot description
        popup.transform.GetChild(3).GetComponent<Text>().text = nameText.text; // slot nameText
    }

    //void findmySo()
    //{
    //    selectedTool = null; // Reset in case it's reused

    //    for (int i = 0; i < toolShop.Tools.Count; i++)
    //    {
    //        Tool toolInSlot = toolShop.Tools[i].GetTool(); // we got all the tool info here 
    //        Debug.Log("Tool nameText" + toolInSlot.nameText);
    //        Debug.Log("Tool nameText in popup" + popup.transform.GetChild(3).GetComponent<Text>().text);

    //        if (toolInSlot != null && toolInSlot.nameText == popup.transform.GetChild(3).GetComponent<Text>().text)
    //        {
    //            selectedTool = toolInSlot;
    //            Debug.Log("Tool nameText" + toolInSlot.nameText);
    //            break;
    //        }
    //    }
    //}
    public void AddToCart()
    {
       // findmySo();

        if (selectedTool != null )
        {
            toolShop.Remove(selectedTool);

            buyingCount++;
            buyingCountText.text = "" + buyingCount;
        }
        else
        {
            Debug.LogWarning("Matching tool not found for the sprite.");
        }
       
        TransferInfo();

    
    }

    //private void Reset()
    //{
    //    selectedTool = null; // Reset in case it's reused
    //    buyingCount = 1;
    //    ischanged = true;

    //}

    public void ClosePopup()
    {
        popup.SetActive(false);
        //Reset();
    }
}
