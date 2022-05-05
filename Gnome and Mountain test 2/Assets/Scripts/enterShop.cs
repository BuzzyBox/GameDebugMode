using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using UnityEngine.EventSystems;

public class enterShop : MonoBehaviour
{
    //DialogueManager dialogueManager;
    //public TextAsset inkJSON;
    //private Story TestStory;
    //public bool dialogueChoice { get; private set; }
    //public string key;

    //[Header("Choice 0")]
    //[SerializeField] GameObject[] choice0;

    //DialogueManager dialogueManager;

    //UI For shop 
    [Header("Shop UI")]
    [SerializeField] private GameObject shopUI;

    public DialogueManager dialogueManager;
    [Header("Choice 0")]
    [SerializeField] private GameObject[] choice0;

    public bool isSelected; 



    void Start()
    {
      dialogueManager = GetComponent<DialogueManager>();
      shopUI.SetActive(false);
    
    }

    void Update()
    {
       // int choiceIndex = 0;
       // dialogueManager.MakeChoice(choiceIndex);
            

       //for (int i = 0; i > choice0.Length i++)
       // {
       //     GameObject choice = choice0[i];
       //     choice
       // }
 


        //if(Input.GetKeyDown(KeyCode.Z) && choice0[0])
        //{
          //  isSelected = true;
           // Debug.Log("Enter shop");
           
            //for(int i = 0; i < choice0.Length; i++)
            //{
            //    choice0[i].SetActive(false);
            //    Debug.Log("Enter shop");
            //}
        //}

        //if(choice0[0].CompareTag("True"))
        //{
        // if(Input.GetKeyDown(KeyCode.Return))
        //    {
        //   dialogueManager.gameObject.SetActive(!dialogueManager.gameObject.activeSelf);
        //    Debug.Log("I have enter shop");
        //     }
        //}

            //if(Input.GetKeyDown(KeyCode.Return))
           // {
           // }
        
          //  EventSystem.current.SetSelectedGameObject(this.gameObject);
      
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
            
        }
    }

}
