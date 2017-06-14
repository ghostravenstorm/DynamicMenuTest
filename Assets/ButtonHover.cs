using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler{

   public void OnPointerEnter(PointerEventData data){
      //Debug.Log(data.pointerCurrentRaycast);

      if(Menu.loadedScene != null){
         Debug.Log("A scene is loaded. Unloading " + Menu.loadedScene);
         SceneManager.UnloadSceneAsync(Menu.loadedScene);
      }
      else{
         Debug.Log("No scene is currently laoded.");
      }


      ButtonData btnData =
         data.pointerCurrentRaycast.gameObject.GetComponent<ButtonData>();

      //Debug.Log(data.pointerCurrentRaycast.gameObject.name);

      if(btnData == null){
         Debug.Log("Button has no data. Exiting routine.");
         return;
      }
      else{
         Debug.Log("Button data acquired.");
      }

      Debug.Log("Loading " + btnData.scene);
      Menu.loadedScene = btnData.scene;
      SceneManager.LoadSceneAsync(btnData.scene, LoadSceneMode.Additive);
   }

   public void OnPointerExit(PointerEventData data){

   }

}
