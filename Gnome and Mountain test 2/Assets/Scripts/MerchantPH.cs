using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerchantPH : MonoBehaviour
{
    public TextAsset inkJSON;
    private Story TestStory;

    void Start()
    {
        TestStory = new Story(inkJSON.text);
        Debug.Log(TestStory.Continue());
    }

    void Update()
    {
        
    }
}
