using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TempleStage : MonoBehaviour
{
    public WellsCtr wellsCtr;
    public TeleControl teleControl;
    public Animator templeAniA;
    public Animator templeAniB;
    public float TimeBeforeTeleApper = 5;
    public float TimeBeforeTempleAAni = 5;
    public float TimeBeforeTempleBAni = 5;
    public float TimeBeforeTempleGame = 15;
    public UnityEvent findGame;
    public UnityEvent findGameEnd;

    private void Start()
    {
        WellIntro();
    }

    [ContextMenu("WellIntro")]
    public void WellIntro()
    {
        wellsCtr.OutWellApper();
        LeanTween.delayedCall(4, () => DialogueSystem.instance.StartDialog("TempleStart"));
        LeanTween.delayedCall(TimeBeforeTeleApper, () => teleControl.PortalApper());
    }

    [ContextMenu("StartStage")]
    public void StartStage()
    {
        teleControl.gameObject.SetActive(false);
        wellsCtr.InWellApper();
       // LeanTween.delayedCall(2, () => DialogueSystem.instance.StartDialog("TempleStart"));
        LeanTween.delayedCall(TimeBeforeTempleAAni, () =>
        {
            DialogueSystem.instance.StartDialog("TempleInfo1");
            templeAniA.Play("Drop");
            SecondTempleDrop();
        });
        Debug.Log("TempleAAni");
    }



    public void SecondTempleDrop()
    {

        LeanTween.delayedCall(TimeBeforeTempleBAni, () =>
        {
            DialogueSystem.instance.StartDialog("TempleInfo2");
            templeAniB.Play("Drop");
            GameIntro();
        });
        Debug.Log("GameIntro");
    }

    public void GameIntro()
    {
        LeanTween.delayedCall(TimeBeforeTempleGame, () =>
        {
            DialogueSystem.instance.StartDialog("TempleGameInfo");
            findGame?.Invoke();
        });



    }

    public void GameEnd()
    {
        findGameEnd?.Invoke();
        DialogueSystem.instance.StartDialog("FindedOffical");
        Debug.Log("End");
    }
}
