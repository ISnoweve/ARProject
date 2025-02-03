using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ArImageTrackSpawn : MonoBehaviour
{
    private ARTrackedImageManager _imageManager;
    private ARSession aRSession;

    public GameObject SpawnPre;
    private GameObject spwanedGameObjects;

    private void Awake()
    {
        _imageManager = FindObjectOfType<ARTrackedImageManager>();

        aRSession=FindObjectOfType<ARSession>();
       
    }

    private void OnEnable()
    {
        _imageManager.trackedImagesChanged += OnImageChange;

    }



    private void OnDisable()
    {
        _imageManager.trackedImagesChanged -= OnImageChange;

    }

    private void OnImageChange(ARTrackedImagesChangedEventArgs args)
    {

        foreach (ARTrackedImage aRTrackedImage in args.added)
        {
            UpdateImage(aRTrackedImage);
        }
        foreach (ARTrackedImage aRTrackedImage in args.updated)
        {
            UpdateImage(aRTrackedImage);
        }

        foreach (ARTrackedImage aRTrackedImage in args.removed)
        {
            DisableObject(aRTrackedImage);
        }
    }

    private void DisableObject(ARTrackedImage aRTrackedImage)
    {

    }

    private void UpdateImage(ARTrackedImage aRTrackedImage)
    {
        if (aRTrackedImage.referenceImage.name != "Test")
            return;
        if (spwanedGameObjects != null)
            return;

            spwanedGameObjects = Instantiate(SpawnPre, aRTrackedImage.transform.position, aRTrackedImage.transform.rotation);
            StartCoroutine(SetPos(aRTrackedImage));
        
        

        //if (aRTrackedImage.referenceImage.name != arObject.name)
        //    return;
        //if (spwanedGameObjects == null)
        //{
        //    spwanedGameObjects = Instantiate(arObject);
        //    DialogSystem.instance.NextDialog();

        //}
        //Mainsys.instance.DiableScanUI();

        //spwanedGameObjects.SetActive(true);


    }

    private IEnumerator SetPos(ARTrackedImage aRTrackedImage)
    {
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => aRTrackedImage.trackingState == TrackingState.Tracking);
        spwanedGameObjects.transform.position = aRTrackedImage.transform.position;
        spwanedGameObjects.transform.rotation = aRTrackedImage.transform.rotation;
        spwanedGameObjects.AddComponent<ARAnchor>();
        spwanedGameObjects.SetActive(true);
    }

    [ContextMenu("TestSpawn")]
    public void TestSpawn()
    {
        if (spwanedGameObjects == null)
        {
            spwanedGameObjects = Instantiate(SpawnPre);
            spwanedGameObjects.transform.position = Vector3.zero;
            spwanedGameObjects.transform.rotation = Quaternion.identity;
            spwanedGameObjects.AddComponent<ARAnchor>();
            spwanedGameObjects.SetActive(true);
        }
    }
}
