using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ARObjectAllStuffPartThree : MonoBehaviour
{
    public static ARObjectAllStuffPartThree Instance;
    public Animator animator;

    public int missionCount;
    public int missionCompleteCount;
    public UnityEvent onMissionComplete;
    
    public float eventTimeOpening;
    public float eventTimeEnding;

    private void Awake()
    {
        Instance = this;
        gameObject.SetActive(true);
        animator = GetComponent<Animator>();

       // OnOpening();
    }


    [ContextMenu("OnOpening")]
    public void OnOpening()
    {
        PlayAnimation("Spawn");
    }

    public void OnAnimationEnd(string animationName)
    {
    }

    private void PlayAnimation(string animationName)
    {
        animator.SetTrigger(animationName);
    }

    private IEnumerator PlayAnimationOpening()
    {
        yield return new WaitForSeconds(eventTimeOpening);
    }
    
    private IEnumerator PlayAnimationEnding()
    {
        yield return new WaitForSeconds(eventTimeEnding);
    }
    
    public void IncreaseMissionCount()
    {
        missionCompleteCount++;
        if(missionCompleteCount == missionCount)
        {
            onMissionComplete.Invoke();
        }
    }
}
