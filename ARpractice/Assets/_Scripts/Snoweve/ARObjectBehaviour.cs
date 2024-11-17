using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ARObjectBehaviour : MonoBehaviour
{
    public string id;
    public Animator animator;
    
    private void Start()
    {
        ARObjectSpawnSystem.Instance.ARObjectDictionary.Add(id, this); 
        animator = GetComponent<Animator>();
        gameObject.SetActive(false);
    }

    public abstract void OnSpawn();

    public abstract void OnDeSpawn();
    
    public abstract void RegisterSystem();
    
    public abstract void UnRegisterSystem();

    public abstract void RegisterEvent();

    public abstract void UnRegisterEvent();
    
    public abstract void OnAnimationEnd(string animationName);
}
