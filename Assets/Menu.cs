using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Menu : MonoBehaviour{

   // Global variable accessed by every ButtonHover instance so they know which
   // scene to unload before loading their's.
   public static string loadedScene;

   public string defaultScene;

   void Start(){

      // Set the default scene at start.
      if(defaultScene != null){
         loadedScene = defaultScene;
         SceneManager.LoadSceneAsync(defaultScene, LoadSceneMode.Additive);
      }

   }
}
