using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class StartButton : MonoBehaviour
{

  [MenuItem("Run/Play %g")]
  public static void GoToStartScene()
  {
    EditorSceneManager.OpenScene("Assets/Mediapipe/Samples/Scenes/Start Scene.unity");
    EditorApplication.EnterPlaymode();
  }
  
  [MenuItem("Run/Stop")]
  public static void StopScene()
  {
    EditorApplication.ExitPlaymode();
  }
  
  [MenuItem("Run/Return %h")]
  public static void ReturnToEditingScene()
  {
    EditorSceneManager.OpenScene("Assets/Scenes/AvatarView.unity");
  }
  
}
