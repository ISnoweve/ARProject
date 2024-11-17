using System;
using System.Collections.Generic;
using UnityEngine;

public class ARObjectSpawnSystem : MonoBehaviour
{
    public static ARObjectSpawnSystem Instance { get; private set; }
    public Dictionary<string, ARObjectBehaviour> ARObjectDictionary;

    public Action<ARObjectBehaviour> OnSpawn;

    private void Awake()
    {
        Instance = this;
        ARObjectDictionary = new Dictionary<string, ARObjectBehaviour>();
    }

    public void SpawnObject(ARObjectBehaviour arObjectBehaviour)
    {
        arObjectBehaviour.OnSpawn();
        OnSpawn?.Invoke(arObjectBehaviour);
    }
}
