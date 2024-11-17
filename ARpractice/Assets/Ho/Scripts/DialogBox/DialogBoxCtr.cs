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

    internal void ShowDialog(string text)
    {
        dialog.text = text;
        if (shown)
            return;
        shown = true;
        LeanTween.value(0, 1, 1).setOnUpdate((float val) => cg.alpha = val);
    }
    internal void HideDialog()
    {
        if (!shown)
            return;
        shown = false;
        LeanTween.value(1, 0, 1).setOnUpdate((float val) => cg.alpha = val);
    }

}
