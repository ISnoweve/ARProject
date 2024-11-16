using System;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSystem : MonoBehaviour
{
    public static AnimationSystem Instance { get; private set; }
    public Dictionary<string,Animator> AnimationDictionary = new Dictionary<string, Animator>();

    public Action<string,string> OnAnimationEnd;

    private void Awake()
    {
        Instance = this;
    }

    public void RegisterDictionary(string id, Animator animator)
    {
        AnimationDictionary.Add(id, animator);
    }

    public void UnRegisterDictionary(string id)
    {
        AnimationDictionary.Remove(id);
    }

    public void PlayAnimation(string id, string animationName)
    {
        if (AnimationDictionary.ContainsKey(id))
        {
            AnimationDictionary[id].SetTrigger(animationName);
        }
    }

    public void AnimationEnd(string id, string animationName)
    {
        OnAnimationEnd?.Invoke(id, animationName);
    }
}
