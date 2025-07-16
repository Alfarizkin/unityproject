using UnityEngine;
using UnityEngine.XR.ARFoundation;
using System.Collections.Generic;

public class FilterManager : MonoBehaviour
{
    public Material[] filterMaterials; // Assign di Inspector
    public ARFaceManager faceManager;  // Assign ARFaceManager di Inspector

    public void ChangeFilter(int index)
    {
        if (filterMaterials != null && index < filterMaterials.Length && faceManager != null)
        {
            foreach (ARFace face in faceManager.trackables)
            {
                var renderer = face.GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.sharedMaterial = filterMaterials[index];
                }
            }
        }
    }
}