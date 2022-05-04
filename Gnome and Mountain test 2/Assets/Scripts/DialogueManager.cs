using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{
    /*Will need to make a choice dialouge here soon for the store
     Basically how I think it will go that I'll make a new script 
     Make a component to it and make a boolean if true*/


  private static DialogueManager instance;

    [Header("Params")]
    [SerializeField] private float typingSpeed = 0.02f;

    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;

    [SerializeField] private TextMeshProUGUI dialogueText;

    //Choice code 
    [Header("Choice UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choiceText;


    private Story currentStory;
    public bool dialogueIsPlaying { get; private set; }



    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Found more than one Dialogue Manager in the sence");
        }


        instance = this;
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);

        //getting all choices text
        choiceText =  new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choiceText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }


    }

    private void Update()
    {
        if(!dialogueIsPlaying)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {

            ContinueStory();


        }


    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
        ContinueStory();


    }
    private void ExitDialogueMode()
    {
       // yield return new WaitForSeconds(0.2f);
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";


    }

    private void ContinueStory()
    {

        if(currentStory.canContinue)
        {
            //set text for current dialogue line 

           dialogueText.text = currentStory.Continue();

            //Display choices
            DisplayChoices();


           //StartCoroutine(displayLine(currentStory.Continue()));

        }
        else
        {
           ExitDialogueMode();

          //StartCoroutine(ExitDialogueMode());

        }
    
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("More choices were given than the UI can support. Number of choices given" + currentChoices.Count);
        }
            
       int index = 0;

        foreach(Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choiceText[index].text = choice.text;
            index++;
        }

        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }

        StartCoroutine(selectFirstChoice());

    }

    private IEnumerator selectFirstChoice()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);

        }


    }

    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);

        
    }

    private IEnumerator displayLine(string line)
    {
        dialogueText.text = "";

        foreach (char letter in line.ToCharArray())
        {

            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);

        }

    }




}
