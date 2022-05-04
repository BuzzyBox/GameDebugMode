using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class enterShop : MonoBehaviour
{

    public TextAsset inkJSON;
    private Story TestStory;
    public bool dialogueChoice { get; private set; }

    void Start()
    {
        
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("I have enter shop");
        }
        else
        {

        }

    }
}
