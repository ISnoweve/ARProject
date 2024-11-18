using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARObjectAllStuff : MonoBehaviour
{
    public Animator animator;


    public float eventTimeOne;
    public float eventTimeTwo;
    public float eventTimeOfficeTalk;
    public float eventTimeThree;
    public float eventTimeLittleWellLastTalk;
    public float eventTimeFour;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        
        // gameObject.SetActive(false);
    }


    [ContextMenu("Onspawn")]
    public void OnSpawn()
    {
      //  gameObject.SetActive(true);
        PlayAnimation("Spawn");
    }

    public void OnAnimation(string animationName)
    {
        
    }

    public void OnAnimationEnd(string animationName)
    {

        if (animationName == "Spawn")
        {
            StartCoroutine(PlayAnimationDialogOne());
        }

        if (animationName == "DialogOne")
        {
            StartCoroutine(PlayAnimationDialogTwo());
        }
        
        if (animationName == "DialogTwo")
        {
            StartCoroutine(PlayAnimationDialogThree());
        }
        
        if (animationName == "DialogThree")
        {
            StartCoroutine(PlayAnimationDialogFour());
        }
        
        if (animationName == "End")
        {
            Debug.LogError("End AHAHHHHHHHHHHHHHHHHHHHAHAHHA");
        }
    }
    
    public void PlayAnimation(string animationName)
    {
        animator.SetTrigger(animationName);
    }

    // LittleWell up hand animation and DialogOne talk
    public IEnumerator PlayAnimationDialogOne()
    {
      
        yield return new WaitForSeconds(eventTimeOne);
        OnAnimationEnd("DialogOne");
    }
    
    // Paper spawning and DialogTwo talk
    public IEnumerator PlayAnimationDialogTwo()
    {
        //LittleWell talk something
     
        PlayAnimation("OfficeComeIn");
        yield return new WaitForSeconds(eventTimeTwo);
        OnAnimationEnd("DialogTwo");
    }
    
    public IEnumerator PlayAnimationDialogThree()
    {
        //Office and LocalOffice Talk something
        yield return new WaitForSeconds(eventTimeOfficeTalk);
        PlayAnimation("LocalOfficeAndOfficeLeave");
        yield return new WaitForSeconds(eventTimeThree);
        OnAnimationEnd("DialogThree");
    }
    
    public IEnumerator PlayAnimationDialogFour()
    {
        //LittleWell last talk
        Debug.LogError("LittleWell last talk");
        yield return new WaitForSeconds(eventTimeFour);
        //LeanTween.value(0,1,1).setOnUpdate((float value) =>
        //{
        //    teleport.SetFloat("_DissolveAmount", value);
        //});
        yield return new WaitForSeconds(eventTimeFour);
        OnAnimationEnd("End");
    }
}
