using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

public class ImageRecognition : MonoBehaviour
{
    public ARTrackedImageManager _arTrackedImageManager;
    public GameObject prefabObject;

    private void Awake()
    {
        _arTrackedImageManager = FindObjectOfType<ARTrackedImageManager>();
    }

    public void OnEnable()
    {
        _arTrackedImageManager.trackedImagesChanged += OnImageChanged;
    }

    public void OnDisable()
    {
        _arTrackedImageManager.trackedImagesChanged -= OnImageChanged;
    }

    public void OnImageChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach (var trackedImage in args.added)
        {
            Instantiate(prefabObject, trackedImage.transform.position, 
                prefabObject.transform.rotation);
        }
    }

    void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (ARTrackedImage trackedImage in eventArgs.added)
        {
            // Give the initial image a reasonable default scale
            trackedImage.transform.localScale =
                new Vector3(-trackedImage.referenceImage.size.x, 0.005f, -trackedImage.referenceImage.size.y);
        }

        foreach (ARTrackedImage trackedImage in eventArgs.updated)
        {
            // Give the initial image a reasonable default scale
            trackedImage.transform.localScale =
                new Vector3(-trackedImage.referenceImage.size.x, 0.005f, -trackedImage.referenceImage.size.y);
        }
    }

}
