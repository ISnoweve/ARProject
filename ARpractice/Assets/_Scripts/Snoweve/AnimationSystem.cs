using System;
using UnityEngine;

public class AnimationSystem : MonoBehaviour
{
    public Animator animator;
    public Action<string> OnAnimationEnd;

    private void Awake()
    {
        // switch to register dialogSystem action 
        OnAnimationEnd += PlayAnimation;
        
        PlayFirstAnimation();
    }

    public void PlayFirstAnimation()
    {
        PlayAnimation("ABC");
    }

    private void PlayAnimation(string animationName)
    {
        animator.SetTrigger(animationName);
    }

    public void AnimationEnd(string animationName)
    {
        OnAnimationEnd?.Invoke(animationName);
    }
}
