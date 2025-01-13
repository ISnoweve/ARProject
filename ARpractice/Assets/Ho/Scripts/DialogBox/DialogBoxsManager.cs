using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[DefaultExecutionOrder(-10)]
public class DialogBoxsManager : MonoBehaviour
{
    internal static DialogBoxsManager instance;
    private Dictionary<string, DialogBoxCtr> dialogBoxs;


    private void Awake()
    {
        instance = this;
        dialogBoxs = new();

    }

    private void OnEnable()
    {
        DialogueSystem.OnDialogueSet += ShowDialog;
        DialogueSystem.onSectionEnd += HideAllDialog;

    }


    private void OnDisable()
    {
        DialogueSystem.OnDialogueSet -= ShowDialog;
        DialogueSystem.onSectionEnd -= HideAllDialog;
    }

    internal void ShowDialog(string charaterID, string content)
    {
        foreach (var dialog in dialogBoxs)
        {
            if (dialog.Key == charaterID)
            {
                dialogBoxs[charaterID].ShowDialog(content);
            }
            else
                dialog.Value.HideDialog();
        }
        //if (!dialogBoxs.ContainsKey(charaterID))
        //{

        //    Debug.LogError("Charater " + charaterID +" is not existed");
        //    return;
        //}
        //dialogBoxs[charaterID].ShowDialog(content);

    }

    internal void HideDialog(string charaterID)
    {
        if (!dialogBoxs.ContainsKey(charaterID))
        {
            Debug.LogError("CharaterID key is not existed");
            return;
        }
        dialogBoxs[charaterID].HideDialog();
    }

    public void AddDialogBox(DialogBoxCtr dialogBoxCtr)
    {
        if (dialogBoxs.ContainsKey(dialogBoxCtr.charaterID))
        {
            Debug.LogError("Same dialogBox key is existed");
            return;
        }
        dialogBoxs.Add(dialogBoxCtr.charaterID, dialogBoxCtr);

    }
    public void DelectDialogBox(string charaterID)
    {
        Debug.Log("Removed");
        if (!dialogBoxs.ContainsKey(charaterID))
        {
            return;
        }
        //dialogBoxs.Remove(charaterID);

    }


    private void HideAllDialog()
    {
        foreach (var dialog in dialogBoxs)
        {
            dialog.Value.HideDialog();
        }
    }

    [ContextMenu("T1")]
    public void Test1()
    {
        dialogBoxs["Well"].ShowDialog("ด๚ธี1");
    }

    [ContextMenu("T2")]
    public void Test2()
    {
        dialogBoxs["Well"].ShowDialog("ด๚ธี2");
    }

    [ContextMenu("T3")]
    public void Test3()
    {
        dialogBoxs["Well"].HideDialog();
    }



}
