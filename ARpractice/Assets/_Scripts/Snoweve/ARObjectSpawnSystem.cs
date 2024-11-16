using System;
using UnityEngine;

public class ARObjectSpawnSystem : MonoBehaviour
{
    public static ARObjectSpawnSystem Instance { get; private set; }
    
    public Action<ARObjectBehaviour> OnSpawn;

    public void SpawnObject(ARObjectBehaviour arObjectBehaviour)
    {
        GameObject arObject = Instantiate(arObjectBehaviour.gameObject);
        arObjectBehaviour.OnSpawn();
        OnSpawn?.Invoke(arObjectBehaviour);
    }
    
    public void DeSpawnObject(ARObjectBehaviour arObjectBehaviour)
    {
        arObjectBehaviour.OnSpawn();
        OnSpawn?.Invoke(arObjectBehaviour);
    }
}
