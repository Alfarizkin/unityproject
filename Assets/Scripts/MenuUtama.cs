using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  void Start()
  {
    Screen.orientation = ScreenOrientation.Portrait;

    // Pastikan AR Session di-reset ketika kembali ke main menu
    if (ARSessionManager.Instance != null)
    {
      ARSessionManager.Instance.DisableARSession();
    }
  }

  public void Exit()
  {
    Application.Quit();
    Debug.Log("Anda Telah Keluar Dari Aplikasi");
  }

  public void About()
  {
    SceneManager.LoadScene("About");
  }

  public void MenuAR()
  {
    StartCoroutine(LoadARScene());
  }

  public void MenuFilterCamera()
  {
    StartCoroutine(LoadFaceFilterScene());
  }

  private IEnumerator LoadARScene()
  {
    // Reset sebelum load scene baru
    if (ARSessionManager.Instance != null)
    {
      ARSessionManager.Instance.ResetARSession();
    }

    yield return new WaitForSeconds(0.2f);
    SceneManager.LoadScene("ARScene");
  }

  private IEnumerator LoadFaceFilterScene()
  {
    // Reset sebelum load scene baru
    if (ARSessionManager.Instance != null)
    {
      ARSessionManager.Instance.ResetARSession();
    }

    yield return new WaitForSeconds(0.2f);
    SceneManager.LoadScene("MenuFilterCamera");
  }
}