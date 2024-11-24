using System;
using UnityEngine;

public class GazeObject : MonoBehaviour
{
    InfoBehaviour infoBehaviour;

    private void Awake()
    {
        infoBehaviour = GetComponentInChildren<InfoBehaviour>();
    }

    public void OnGazeEnter()
    {
        Debug.Log(  gameObject.name+"Gaze Enter");
    }
}
