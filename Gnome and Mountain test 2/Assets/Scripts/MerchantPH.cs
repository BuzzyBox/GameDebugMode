using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerchantPH : MonoBehaviour
{

    


    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    public TextAsset inkJSON;
    private Story TestStory;

    private bool playerinRange;

    void Start()
     {

        TestStory = new Story(inkJSON.text);
       // Debug.Log(TestStory.Continue());
     }



    private void Awake()
    {
        playerinRange = false;
        visualCue.SetActive(false);
    }

    private void Update()
    {
        
        if(playerinRange && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            visualCue.SetActive(true);
            if(Input.GetKeyDown(KeyCode.Z))
            {

                DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
                Debug.Log("TextHere");

            }
            
        }
        if(DialogueManager.GetInstance().dialogueIsPlaying)
        {
            visualCue.SetActive(false);
        }

    }



    private void OnTriggerEnter2D(Collider2D collider)
    {
        
        if (collider.gameObject.tag == "Player")
        {
            playerinRange = true;
        }


    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            playerinRange = false;
        }

        
    }






    //public TextAsset inkJSON;
    //private Story TestStory;

    //void Start()
    //{
    //    TestStory = new Story(inkJSON.text);
    //    Debug.Log(TestStory.Continue());
    //}

    //void Update()
    //{

    //}









}
