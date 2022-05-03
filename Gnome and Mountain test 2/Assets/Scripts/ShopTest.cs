using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class ShopTest : MonoBehaviour
{
    /* I am going to make some difference here from the tutorial I am learning from
     * Rather than making a text variable I am going to link it back to tag and see 
     * Where I go from there*/

    public int[,] shopItems = new int[3, 3];
    
    
    public float coinPrice;
    public string coinName;


    void Start()
    {
        //Items 
        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;

        //Price 
        shopItems[2, 1] = 1;
        shopItems[2, 2] = 10;
        shopItems[2, 3] = 20;


    }

    public void Buy()
    {
        GameObject selectedItem = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;
        if(coinPrice >= shopItems[2, selectedItem.GetComponent<BuyTest1>().itemID])
        {
            
        }
        
    
    }
}
