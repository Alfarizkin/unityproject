using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;

public class arscene : MonoBehaviour
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

        ARCameraManager cameraManager = FindObjectOfType<ARCameraManager>();
        if (cameraManager != null)
        {
            cameraManager.enabled = false;
        }

        ARTrackedImageManager imageManager = FindObjectOfType<ARTrackedImageManager>();
        if (imageManager != null)
        {
            imageManager.enabled = false;
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