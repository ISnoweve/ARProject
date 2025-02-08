using System;
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
    public UnityEvent InfoStart;
    private void Start()
    {
        WellApper();
    }

    private void WellApper()
    {
        wellsCtr.OutWellApper();
        InGazeCheck.instance.SetTargetKey("TempleStage");
    }


    public void WellIntro()
    {
        wellsCtr.outWellCtr.StopApperEffect();
        LeanTween.delayedCall(1, () => {         
        DialogueSystem.instance.StartDialog("TempleStart");
        AndriodInput.instance.EnableNextDialog(true);
        DialogueSystem.onSectionEnd += PortalApper;
        });
    }


    public void PortalApper()
    {
        Hints.instance.Show("�i�J�ǰe��");
        AndriodInput.instance.EnableNextDialog(false);
        DialogueSystem.onSectionEnd -= PortalApper;
        DialogueSystem.instance.StartDialog("TempleStartKeep");
        teleControl.PortalApper();

    }


    public void StartStage()
    {
        Hints.instance.Hide();
        teleControl.gameObject.SetActive(false);
        wellsCtr.InWellApper();
        LeanTween.delayedCall(2, () => FirstDrop());


    }

    private void FirstDrop()
    {
        Debug.Log("TempleAAni");
        DialogueSystem.instance.StartDialog("TempleInfo1");
        AndriodInput.instance.EnableNextDialog(true);
        templeAniA.Play("Drop");
        DialogueSystem.onSectionEnd += SecondTempleDrop;
    }

    public void SecondTempleDrop()
    {
        AndriodInput.instance.EnableNextDialog(false);
        DialogueSystem.onSectionEnd -= SecondTempleDrop;
        LeanTween.delayedCall(2, () =>
            {
                DialogueSystem.instance.StartDialog("TempleInfo2");
                AndriodInput.instance.EnableNextDialog(true);
                templeAniB.Play("Drop");
                Debug.Log("GameIntro");
                DialogueSystem.onSectionEnd += GameIntro;
            });


    }

    public void GameIntro()
    {
        AndriodInput.instance.EnableNextDialog(false);
        Hints.instance.Show("�M��ú˷ǩx��");
        DialogueSystem.onSectionEnd -= GameIntro;
        DialogueSystem.instance.StartDialog("TempleGameInfo");
        findGame?.Invoke();


    }

    public void GameEnd()
    {
        SoundPlayer.instance.PlayCorrect();
        Hints.instance.Hide();
        findGameEnd?.Invoke();
        AndriodInput.instance.EnableNextDialog(true);
        DialogueSystem.instance.StartDialog("FindedOffical");
        Debug.Log("End");
        DialogueSystem.onSectionEnd += StartSearchIntro;
    }

    public void StartSearchIntro()
    {
        DialogueSystem.onSectionEnd -= StartSearchIntro;
        DialogBoxsManager.instance.HideAllDialog();
        AndriodInput.instance.EnableNextDialog(false);
        InfoStart.Invoke();
    }
}
