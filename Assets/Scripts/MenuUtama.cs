using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }
    public void Exit()
  {
    Application.Quit();
    Debug.Log("Anda Telah Keluar Dari Aplikasi");
  }

   public void About() {
     SceneManager.LoadScene("About");
   }

   public void MenuAR() {
     SceneManager.LoadScene("ARScene");
   }

   public void MenuFilterCamera() {
     SceneManager.LoadScene("MenuFilterCamera");
   }
}
