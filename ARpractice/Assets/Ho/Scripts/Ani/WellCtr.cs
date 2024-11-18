using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WellCtr : MonoBehaviour
{
    public Material waterMateral;
    public Material wellMateral;

    public void Start()
    {
        waterMateral.SetFloat("_Amount", 0);
        wellMateral.SetFloat("_Amount", 0);
    }


    [ContextMenu("ShowWell")]
    public void ShowWell()
    {
        LeanTween.value(0, 1, 0.5f).setOnUpdate((float val) => wellMateral.SetFloat("_Amount", val));
    }

    [ContextMenu("ShowWater")]
    public void ShowWater()
    {
        LeanTween.value(0, 1, 0.5f).setOnUpdate((float val) => waterMateral.SetFloat("_Amount", val));
    }


    [ContextMenu("HideWell")]
    public void HideWell()
    {
        LeanTween.value(1, 0, 0.5f).setOnUpdate((float val) => wellMateral.SetFloat("_Amount", val));
    }

    [ContextMenu("HideWater")]
    public void HideWater()
    {
        LeanTween.value(1, 0, 0.5f).setOnUpdate((float val) => waterMateral.SetFloat("_Amount", val));
    }
}
