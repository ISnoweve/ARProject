using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BridgeStage : MonoBehaviour
{
    public WellsCtr wellsCtr;
    public TeleControl teleControl;
    public float TimeBeforeTeleApper = 10;
    public float TimeBeforeGame = 3;
    public UnityEvent GameStartEvent;
    private void Start()
    {
        WellIntro();
    }


    [ContextMenu("WellIntro")]
    public void WellIntro()
    {
        HandControl.instance.SetCanTouch(false);
        wellsCtr.OutWellApper();
        LeanTween.delayedCall(4, () => DialogueSystem.instance.StartDialog("BridgeIntro"));
        LeanTween.delayedCall(TimeBeforeTeleApper, () => teleControl.PortalApper());
    }


    [ContextMenu("StartStage")]
    public void StartStage()
    {
        teleControl.gameObject.SetActive(false);
        wellsCtr.InWellApper();

        DialogueSystem.instance.StartDialog("BridgeIntro2");
        LeanTween.delayedCall(TimeBeforeGame, () =>
        {
            GameStart();
        });
       
    }

    public void GameStart()
    {
        HandControl.instance.SetCanTouch(true);
        Debug.Log("GameStart");
        GameStartEvent?.Invoke();
    }

    [ContextMenu("GameEnd")]
    public void GameEnd()
    {
        HandControl.instance.SetCanTouch(false);
        Debug.Log("GameEnd");
        DialogueSystem.instance.StartDialog("BridgeAfterGame");
    }
}
