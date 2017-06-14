using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Menu : MonoBehaviour{
   public static string loadedScene;
   public string defaultScene;

   void Start(){
      if(defaultScene != null){
         loadedScene = defaultScene;
         SceneManager.LoadSceneAsync(defaultScene, LoadSceneMode.Additive);
      }

   }
}
