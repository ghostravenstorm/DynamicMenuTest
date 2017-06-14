using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler{

   // Hover event that executes the following routine.
   public void OnPointerEnter(PointerEventData ptrData){

      // Check for the scene that is currently loaded.
      if(Menu.loadedScene != null){
         Debug.Log("A scene is loaded. Unloading " + Menu.loadedScene);

         // Unload the scene so it doens't overlap with another.
         SceneManager.UnloadSceneAsync(Menu.loadedScene);
      }
      else{
         Debug.Log("No scene is currently loaded.");
      }

      // Get the game object from the raycast result from the given pointer event
      // data and get any button data from it.
      ButtonData btnData = ptrData.pointerCurrentRaycast.gameObject.GetComponent<ButtonData>();

      // NOTE:
      // Button data in the menu scene is kept on both the button object and it's
      // child Text object. The pointer raycast will hit the Text object first.

      // Check if any data was returned from the raycast.
      if(btnData == null){
         Debug.Log("Button has no data. Exiting routine.");
         return;
      }
      else{
         Debug.Log("Button data acquired.");
      }

      Debug.Log("Loading " + btnData.scene);

      // Set the the current scene to a global variable.
      Menu.loadedScene = btnData.scene;

      // Load the scene by name acquired by the raycast from ButtonData.
      SceneManager.LoadSceneAsync(btnData.scene, LoadSceneMode.Additive);
   }

   // Not important unless something else should happen when pointer exits a
   // button.
   public void OnPointerExit(PointerEventData ptrData){

   }

}
