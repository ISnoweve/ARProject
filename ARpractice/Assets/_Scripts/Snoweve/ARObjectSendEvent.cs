using System;
using Unity.VisualScripting;
using UnityEngine;

public class ARObjectSendEvent : MonoBehaviour
{
    private void Start()
    {

    }
    
    private void OnEnable()
    {
        ARObjectSpawnSystem.Instance.SpawnObject(ARObjectSpawnSystem.Instance.ARObjectDictionary["FootPrint"]);
        ARObjectSpawnSystem.Instance.SpawnObject(ARObjectSpawnSystem.Instance.ARObjectDictionary["LittleWell"]);
    }
}
