using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class SwitchObjects : MonoBehaviour
{
    public GameObject[] Spawned;
    
    private readonly Dictionary<string, GameObject> spawnedPrefabs = new Dictionary<string, GameObject>();
    
    GameObject ARObjSpawned;

    [SerializeField]
    ARTrackedImageManager m_TrackedImageManager;

    public void OnEnable()
    {
        m_TrackedImageManager.trackedImagesChanged += OnChanged;
    }

    public void OnDisable()
    {
        m_TrackedImageManager.trackedImagesChanged -= OnChanged;
    }

    void OnChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (ARTrackedImage trackedImage in eventArgs.added)
        {
            AddedMode(trackedImage);
        }

        foreach (ARTrackedImage trackedImage in eventArgs.updated)
        {
            UpdatedMode(trackedImage);
        }

        foreach (ARTrackedImage trackedImage in eventArgs.removed)
        {
            RemovedMode(trackedImage);
        }
    }

    void AddedMode(ARTrackedImage trackedImage)
    {
        var ImageName = trackedImage.referenceImage.name;

        foreach (var Spawnit in Spawned)

        if (string.Compare(Spawnit.name, ImageName, StringComparison.Ordinal) == 0 && !spawnedPrefabs.ContainsKey(ImageName))
        {
           ARObjSpawned = Instantiate(Spawnit, trackedImage.transform);
           spawnedPrefabs[ImageName] = ARObjSpawned;
        }
        //throw new NotImplementedException();
    }

    void UpdatedMode(ARTrackedImage trackedImage)
    {
        spawnedPrefabs[trackedImage.referenceImage.name].SetActive(trackedImage.trackingState == TrackingState.Tracking);
        //throw new NotImplementedException();
    }
    void RemovedMode(ARTrackedImage trackedImage)
    {
        Destroy(spawnedPrefabs[trackedImage.referenceImage.name]);
        //throw new NotImplementedException();
    }

}