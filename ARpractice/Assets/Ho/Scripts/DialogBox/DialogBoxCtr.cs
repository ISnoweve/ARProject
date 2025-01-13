using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class DialogBoxCtr : MonoBehaviour
{
    public string charaterID;
    public CanvasGroup cg;
    public TMP_Text dialog;

    private bool shown = false;

    internal delegate void DialogBoxEvent();
    internal event DialogBoxEvent OnShowDialog;
    internal event DialogBoxEvent OnHideDialog;
    private void Start()
    {
        cg.alpha = 0;
    }


    private void OnEnable()
    {
        DialogBoxsManager.instance.AddDialogBox(this);
    }

    private void OnDisable()
    {

        DialogBoxsManager.instance.DelectDialogBox(charaterID);

    }
    
    internal void ShowDialog(string text)
    {
        dialog.text = text;
        if (shown)
            return;
        shown = true;
        LeanTween.value(0, 1, 0.5f).setOnUpdate((float val) => cg.alpha = val);
        OnShowDialog?.Invoke();
    }
    internal void HideDialog()
    {
        if (!shown)
            return;
        shown = false;
        LeanTween.value(1, 0, 0.5f).setOnUpdate((float val) => cg.alpha = val);
        OnHideDialog?.Invoke();
    }
    private void Update()
    {
        transform.forward = transform.position- CameraCtr.instance.transform.position   ;
    }
}
