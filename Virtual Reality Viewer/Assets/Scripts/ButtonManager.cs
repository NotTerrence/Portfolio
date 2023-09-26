using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonManager : MonoBehaviour
{
   public void LoadClassroom()
   {
      Debug.Log("Entering Classroom Scene...");
      SceneManager.LoadSceneAsync("Classroom", LoadSceneMode.Single);
   }

   public void LoadHousehold()
   {
      Debug.Log("Entering Household Scene...");
      SceneManager.LoadSceneAsync("Household", LoadSceneMode.Single);
   }

   public void LoadOffice()
   {
      Debug.Log("Entering Office Scene...");
      SceneManager.LoadSceneAsync("Office", LoadSceneMode.Single);
   }

   public void LoadMainMenu()
   {
      Debug.Log("Entering Main Menu Scene...");
      SceneManager.LoadSceneAsync("Main Menu", LoadSceneMode.Single);
   }
}