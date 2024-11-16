using System;
using Unity.VisualScripting;
using UnityEngine;

public class ARObjectSendEvent : MonoBehaviour
{
    public GameObject arObject;
    private void Awake()
    {
        ARObjectSpawnSystem.Instance.SpawnObject(arObject.GetComponent<ARObjectBehaviour>());
    }
}
