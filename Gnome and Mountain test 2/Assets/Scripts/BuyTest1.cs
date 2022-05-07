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

   // public int coins;
    public Upgrade[] upgrades;

    //Reference
    public Transform shopItems;
    public GameObject itemPrefabs;
    public scriptTest1 playerUpgrades;


    //public enterShop shopSystem;
    //public Items item;
    //public Image icon;
    //public TMP_Text itemName;
    //public TMP_Text itemPrice;
    ListingMode mode;


    private void Start()
    {
        foreach(Upgrade upgrade in upgrades)
        {
            GameObject item = Instantiate(itemPrefabs, shopItems);
                
                upgrade.itemRef = item;

            foreach(Transform child in item.transform)
            {
               // Debug.Log("Transform check");
                if (child.gameObject.name == "Quantity")
                {
                    Debug.Log("Quantity check");
                   child.gameObject.GetComponent<Text>().text = upgrade.quantity.ToString();

                }  
                else if(child.gameObject.name == "Name")
                {
                    Debug.Log("Name check");
                    child.gameObject.GetComponent<TextMeshProUGUI>().text = upgrade.name.ToString();
                }
                else if (child.gameObject.name == "Cost")
                {
                    Debug.Log("Price check");
                    child.gameObject.gameObject.GetComponent<TextMeshProUGUI>().text = "$" + upgrade.price.ToString();
                }
                else if(child.gameObject.name == "Image")
                {
                    Debug.Log("Image check");
                    child.gameObject.GetComponent<Image>().sprite = upgrade.icon1;
                }
            }

        }
    }


    public void ListItem(Items item)
    {
        //this.item = item;
        //this.name = item.name;
        //icon.sprite = item.icon;
        //itemPrice.text = item.price.ToString();

    }

    public void returnKey()
    {

        if(Input.GetKeyDown(KeyCode.Z))
        {
            if(mode.Equals(ListingMode.buy))
              {
                Debug.Log("Item");
                //shopSystem.buyItems(item);
              }
        }

       
    }
    //add if needed
    //private void OnGUI()
    //{
    //    itemPrice.text = playercoins.ToString();
    //}

    public enum ListingMode
    {
        buy
    }

}

[System.Serializable] public class Upgrade
{
    public string name;
    public string price;
    public Sprite icon1;
    [HideInInspector] public int quantity;
    [HideInInspector] public GameObject itemRef;
}