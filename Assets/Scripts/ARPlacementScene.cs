using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;

public class ARPlacementScene : MonoBehaviour
{
    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    public void Back()
    {
        StartCoroutine(CleanupAndLoadScene());
    }

    private IEnumerator CleanupAndLoadScene()
    {
        // Disable AR components
        ARSession session = FindObjectOfType<ARSession>();
        if (session != null)
        {
            session.enabled = false;
        }
        // Wait a frame to ensure cleanup
        yield return new WaitForEndOfFrame();

        // Reset AR Session if manager exists
        if (ARSessionManager.Instance != null)
        {
            ARSessionManager.Instance.ResetARSession();
        }

        SceneManager.LoadScene("MenuUtama");
    }
}
