using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GazeInteraction : MonoBehaviour
{
    public Slider detectionSlider;
    public float observationTime = 5.0f;
    private float detectionTime = 0.0f;
    private GameObject infoObject;
    [SerializeField] private bool isDetected = false;
    

    private void Awake()
    {
        detectionSlider.gameObject.SetActive(false);
    }

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider.GetComponent<GazeObject>() != null && !isDetected)
            {
                detectionSlider.gameObject.SetActive(true);
                detectionTime += Time.deltaTime;
                detectionSlider.value = detectionTime / observationTime;
                if(detectionTime >= observationTime)
                {
                    isDetected = true;
                    //用來開啟對話框
                    //infoObject.GetComponentInChildren<InfoBehaviour>().SetInfoActive(true);
                    
                    //這個是用來找對話內容的ID
                    //detectedObject.GetComponentInChildren<GazeObject>().gazeObjectID;
                    
                    //這個是接口，第一個是標題，第二個是內容
                    //infoObject.GetComponentInChildren<InfoBehaviour>().SetInfoText(string.Empty, string.Empty);
                }
            }
            else
            {
                isDetected = false;
                detectionSlider.gameObject.SetActive(false);
                detectionTime = 0.0f;
                detectionSlider.value = 0.0f;
            }
        }
        else
        {
            isDetected = false;
            detectionSlider.gameObject.SetActive(false);
            detectionTime = 0.0f;
            detectionSlider.value = 0.0f;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, transform.forward * 100);
    }
}