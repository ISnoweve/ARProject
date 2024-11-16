using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ARObjectBehaviour : MonoBehaviour
{
    public string id;
    public Animator animator;
    
    public abstract void OnSpawn();

    public abstract void OnDeSpawn();
    
    public abstract void RegisterSystem();
    
    public abstract void UnRegisterSystem();

    public abstract void RegisterEvent();

    public abstract void UnRegisterEvent();

    public abstract void OnAnimation(string animationName);

    public abstract void OnDialog(string dialogId);

    public abstract void OnVoice(string voiceId);

    public abstract void OnAnimationEnd(string animationName);
}
