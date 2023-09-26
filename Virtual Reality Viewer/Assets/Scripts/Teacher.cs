using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teacher : MonoBehaviour
{
   public TextAsset inkJSON;

   private Collider NPCCol;

   void Start()
   {
      NPCCol = GetComponent<Collider>();
   }

   public void onHit()
   {
      Debug.Log(gameObject.name);
      // ON hit, disables collider and gets an instance of the dialogue manager to start dialogue
      NPCCol.enabled = false;
      DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
   }

   public void enableCollider()
   {
      NPCCol.enabled = true;
   }
}