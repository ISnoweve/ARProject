using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameNPCCtr : MonoBehaviour
{
    private DialogBoxCtr dialogBox;
    private Animator ani;
    public float beforeAniDuration=5;
    public string startLog;
    public string worngLog;
    public string correctLog;

    private void Start()
    {
        dialogBox=GetComponentInChildren<DialogBoxCtr>();
        ani=GetComponent<Animator>();
    }

    public void StartPlay()
    {
        dialogBox.ShowDialog(startLog);
    }

    public void ShowWrong()
    {
        dialogBox.ShowDialog(worngLog);
    }

    public void Correct()
    {
        dialogBox.ShowDialog(correctLog);
        LeanTween.delayedCall(beforeAniDuration, () =>
        {
            dialogBox.HideDialog();
            ani.Play("Walk");
        });
    }
}
