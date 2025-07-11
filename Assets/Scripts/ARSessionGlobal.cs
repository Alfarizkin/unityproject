using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARSessionManager : MonoBehaviour
{
    public static ARSessionManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ResetARSession()
    {
        ARSession session = FindObjectOfType<ARSession>();
        if (session != null)
        {
            session.Reset();
        }
    }

    public void DisableARSession()
    {
        ARSession session = FindObjectOfType<ARSession>();
        if (session != null)
        {
            session.enabled = false;
        }
    }
}