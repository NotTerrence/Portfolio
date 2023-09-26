// For more information about Ink. please see https://www.inklestudios.com/ink/
// Ink Quickstart: https://github.com/inkle/ink/blob/master/Documentation/RunningYourInk.md#getting-started-with-the-runtime-api
// Ink Documentation: https://github.com/inkle/ink

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;

public class DialogueManager : MonoBehaviour
{
   private static DialogueManager instance;

   public GameObject dialoguePanel;
   public TextMeshProUGUI dialogueText;
   private Story currentStory;
   public GameObject[] choices;
   private TextMeshProUGUI[] choicesText;

   private GameObject tr;

   private bool isDialoguePlaying;

   private void Awake()
   {
      if (instance != null)
      {
         Debug.LogWarning("Found more than one (1) instance of DialogueManager!");
      }
      instance = this;
   }

   public static DialogueManager GetInstance()
   {
      return instance;
   }

   private void Start()
   {
      isDialoguePlaying = false;
      dialoguePanel.SetActive(false);

      // get all of the choices text 
      choicesText = new TextMeshProUGUI[choices.Length];
      int index = 0;

      // get reference to "Teacher" NPC
      tr = GameObject.Find("/NPC/Teacher");

      // get reference to TextMEshProGUI Dialogue Texts
      foreach (GameObject choice in choices)
      {
         choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
         index++;
      }
   }

   private void Update()
   {
      // return right away if dialogue isn't playing
      if (!isDialoguePlaying)
      {
         return;
      }

      // handle continuing to the next line in the dialogue when button is pressed
      if (currentStory.currentChoices.Count == 0 && Input.GetMouseButtonDown(0))
      {
         ContinueStory();
      }
   }

   public void EnterDialogueMode(TextAsset inkJSON)
   {
      // sets dialogue ui (panel, buttons, text, etc.) to active / visible
      currentStory = new Story(inkJSON.text);
      isDialoguePlaying = true;
      dialoguePanel.SetActive(true);

      ContinueStory();
   }

   private void ExitDialogueMode()
   {
      // sets dialogue ui (panel, buttons, text, etc.) to inactive / invisible
      isDialoguePlaying = false;
      dialoguePanel.SetActive(false);
      dialogueText.text = "";

      // resets "Teacher" to original state
      Teacher teacher = tr.GetComponent<Teacher>();
      teacher.enableCollider();
   }

   private void ContinueStory()
   {
      if (currentStory.canContinue)
      {
         // set text for the current dialogue line
         dialogueText.text = currentStory.Continue();     
         // display choices, if any, for this dialogue line
         DisplayChoices();
      }
      else
      {
         ExitDialogueMode();
      }
   }

   private void DisplayChoices()
   {
      List<Choice> currentChoices = currentStory.currentChoices;

      // check to make sure UI can support the number of choices coming in
      if (currentChoices.Count > choices.Length)
      {
         Debug.LogError("More choices in Ink file than UI can handle!");
      }

      int index = 0;
      // enable and initialize the choices up to the amount of choices for this line of dialogue
      foreach (Choice choice in currentChoices)
      {
         choices[index].gameObject.SetActive(true);
         choicesText[index].text = choice.text;

         index++;
      }
      
      // go through the remaining choices the UI supports and make sure they're hidden
      for (int i = index; i < choices.Length; i++)
      {
         choices[i].gameObject.SetActive(false);
      }
   }

   public void MakeChoice(int choiceIndex)
   {
      currentStory.ChooseChoiceIndex(choiceIndex);
      ContinueStory();
   }
}