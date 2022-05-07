using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using UnityEngine.EventSystems;

public class enterShop : MonoBehaviour
{
    public GameObject shopMenu;
    public scriptTest1 playerCoins;



    //UI For shop 
    [Header("Shop UI")]
    [SerializeField] 
    private GameObject shopUI;

   // public DialogueManager dialogueManager;
    [Header("Choice 0")]
    [SerializeField] private GameObject[] choice0;

    public bool isSelected;



    void Start()
    {
     // dialogueManager = GetComponent<DialogueManager>();
      shopUI.SetActive(false);
    }

    void Update()
    {
      
    }
  
    public void ChoiceMade(int choiceIndex)
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if(choice0[0].gameObject.CompareTag("True"))
            {
                Debug.Log("TextHere");
                shopUI.SetActive(true);

            }
            if (!Input.GetKeyDown(KeyCode.Return))
            {
            
                 ExitShop(choiceIndex);
            }


        }
    }
    //work in process
    public void ExitShop(int shopisClosed)
    {
      if(Input.GetKeyDown(KeyCode.Return))
        {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(shopMenu);
            Debug.Log("ExitShop");
            shopUI.SetActive(false);
        }
        
        
    }

    public void buyItems(Items item)
    {

        if(playerCoins.CoinCollected - item.price < 0)
        {
            return;

        }
            playerCoins.CoinCollected -= item.price;


        //Need to remove the item then give the item to the player 


    }



}
