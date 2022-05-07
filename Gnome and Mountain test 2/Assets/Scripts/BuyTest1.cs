using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuyTest1 : MonoBehaviour
{
    //public int itemID;
    //public string priceText;
    //public GameObject shopManager; 

    public enterShop shopSystem;
    public Items item;
    public Image icon;
    public TMP_Text itemName;
    public TMP_Text itemPrice;
    ListingMode mode;


    public void ListItem(Items item)
    {
        this.item = item;
        this.name = item.name;
        icon.sprite = item.icon;
        itemPrice.text = item.price.ToString();

    }

    public void returnKey()
    {

        if(Input.GetKeyDown(KeyCode.Z))
        {
            if(mode.Equals(ListingMode.buy))
              {
                Debug.Log("Item");
                shopSystem.buyItems(item);
              }
        }

       
    }

    public enum ListingMode
    {
        buy
    }

}
