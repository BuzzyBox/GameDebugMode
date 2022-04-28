using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;

public class DialogueManager : MonoBehaviour
{
  private static DialogueManager instance;

    [Header("Params")]
    [SerializeField] private float typingSpeed = 0.02f;

    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;

    [SerializeField] private TextMeshProUGUI dialogueText;

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
           dialogueText.text = currentStory.Continue();

           //StartCoroutine(displayLine(currentStory.Continue()));

        }
        else
        {
           ExitDialogueMode();

          //StartCoroutine(ExitDialogueMode());

        }
    
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
