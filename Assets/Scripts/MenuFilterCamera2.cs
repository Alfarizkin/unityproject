using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;

public class FaceFilterSceneManager2 : MonoBehaviour
{
    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait; // atau sesuai kebutuhan

        // Reset AR Session saat memulai scene
        StartCoroutine(InitializeAR());
    }

    private IEnumerator InitializeAR()
    {
        if (ARSessionManager.Instance != null)
        {
            ARSessionManager.Instance.ResetARSession();
        }

        yield return new WaitForSeconds(0.5f);

        // Enable AR components untuk face filter
        ARSession session = FindObjectOfType<ARSession>();
        if (session != null)
        {
            session.enabled = true;
        }
    }

    public void Back()
    {
        StartCoroutine(CleanupAndLoadScene());
    }

    private IEnumerator CleanupAndLoadScene()
    {
        // Disable face filter AR components
        ARFaceManager faceManager = FindObjectOfType<ARFaceManager>();
        if (faceManager != null)
        {
            faceManager.enabled = false;
        }

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

        yield return new WaitForEndOfFrame();

        if (ARSessionManager.Instance != null)
        {
            ARSessionManager.Instance.ResetARSession();
        }

        SceneManager.LoadScene("MenuUtama");
    }
}