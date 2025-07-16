using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class FurniturePreviewManager : MonoBehaviour
{
    public GameObject[] furniturePrefabs;
    public Transform previewParent;
    public Camera previewCamera;
    public RawImage previewRender;
    public Button leftButton;
    public Button rightButton;

    private GameObject currentPreview;
    private int currentIndex = 0;

    void Start()
    {
        ShowPreview(currentIndex);

        leftButton.onClick.AddListener(() =>
        {
            currentIndex = (currentIndex - 1 + furniturePrefabs.Length) % furniturePrefabs.Length;
            ShowPreview(currentIndex);
        });

        rightButton.onClick.AddListener(() =>
        {
            currentIndex = (currentIndex + 1) % furniturePrefabs.Length;
            ShowPreview(currentIndex);
        });
    }

    void ShowPreview(int index)
    {
        if (currentPreview != null)
            Destroy(currentPreview);

        currentPreview = Instantiate(furniturePrefabs[index], previewParent);
        currentPreview.transform.localPosition = Vector3.zero;
        currentPreview.transform.localRotation = Quaternion.Euler(0, 180, 0);

        SetLayerRecursively(currentPreview, LayerMask.NameToLayer("FurniturePreview"));
    }

    void SetLayerRecursively(GameObject obj, int layer)
    {
        obj.layer = layer;
        foreach (Transform child in obj.transform)
            SetLayerRecursively(child.gameObject, layer);
    }

    public GameObject GetSelectedPrefab()
    {
        return furniturePrefabs[currentIndex];
    }
}
