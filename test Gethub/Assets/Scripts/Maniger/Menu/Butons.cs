using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Butons : MonoBehaviour
{
   public void Reset()
    {
        SceneManager.LoadScene("Assets/Scenes/Test_Scenes.unity");
    }
  public void exsitGame()
    {
        Application.Quit();
    }
}
