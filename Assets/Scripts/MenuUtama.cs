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

  public void MenuARPlament()
  {
    StartCoroutine(LoadARPlacement());
  }

  public void MenuFilterCamera()
  {
    StartCoroutine(LoadFaceFilterScene());
  }

    public void MenuFilterCamera2()
  {
    StartCoroutine(LoadFaceFilterScene2());
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

  private IEnumerator LoadARPlacement()
  {
    // Reset sebelum load scene baru
    if (ARSessionManager.Instance != null)
    {
      ARSessionManager.Instance.ResetARSession();
    }

    yield return new WaitForSeconds(0.2f);
    SceneManager.LoadScene("ARPlacement");
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

  private IEnumerator LoadFaceFilterScene2()
  {
    // Reset sebelum load scene baru
    if (ARSessionManager.Instance != null)
    {
      ARSessionManager.Instance.ResetARSession();
    }

    yield return new WaitForSeconds(0.2f);
    SceneManager.LoadScene("MenuFilterCamera2");
  }
}