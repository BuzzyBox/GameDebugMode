using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Ink.Runtime;
using TMPro;

public class MenuDebug : MonoBehaviour
{
    //MerchantPH dialougeBox;
    //public TextAsset inkIntrol;
    //private Story beginningTest;
    //[Header("Press Play")]
    //[SerializeField] private GameObject visualCue;
 

    public void buttonPlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    void start()
    {
        //beginningTest = new Story(inkIntrol.text);

    }

    void Update()
    {

        //if(!DialogueManager.GetInstance().dialogueIsPlaying)
        //{
        //    if(Input.GetKeyUp(KeyCode.Return))
        //    {
        //        DialogueManager.GetInstance().EnterDialogueMode(inkIntrol);
        //    }
        //}
        //if (DialogueManager.GetInstance().dialogueIsPlaying)
        //{
        //    visualCue.SetActive(false);
       // }




    }

    //public void StartGame()
    //{
    //    SceneManager.LoadScene(1);
    //}



}
