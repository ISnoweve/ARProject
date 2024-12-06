using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoBehaviour : MonoBehaviour
{
    [SerializeField]private TMP_Text infoTitle;
    [SerializeField]private TMP_Text infoContext;

    private void Start()
    {
        gameObject.SetActive(false);
    }
    
    public void SetInfoActive(bool isGazed)
    {
        gameObject.SetActive(isGazed);
    }
    
    public void SetInfoText(string title, string context)
    {
        infoTitle.text = title;
        infoContext.text = context;
    }
}
