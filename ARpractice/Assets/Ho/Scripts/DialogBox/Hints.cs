using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hints : MonoBehaviour
{
    public DialogBoxCtr dialogBoxCtr;
    internal static Hints instance;
    private void Awake()
    {
           instance = this;
    }

    public void Show(string hint)
    {
        dialogBoxCtr.ShowDialog(hint);
    }

    public void Hide()
    {
        dialogBoxCtr.HideDialog();
    }

}
