using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class DialogBoxsManager : MonoBehaviour
{
    internal static DialogBoxsManager instance;
    public DialogBoxCtr[] dialogBoxCtrs;
    private Dictionary<string, DialogBoxCtr> dialogBoxs = new();
    private void Awake()
    {
        instance = this;
        foreach(DialogBoxCtr dialogBoxCtr in dialogBoxCtrs)
        {
            if(dialogBoxs.ContainsKey(dialogBoxCtr.charaterID))
            {
                Debug.LogError("Same dialogBox key is existed");
                continue;
            }
            dialogBoxs.Add(dialogBoxCtr.charaterID, dialogBoxCtr);
        }
    }

    internal void ShowDialog(string charaterID,string content)
    {
        if (!dialogBoxs.ContainsKey(charaterID))
        {
            Debug.LogError("CharaterID key is not existed");
            return;
        }
        dialogBoxs[charaterID].ShowDialog(content);
    }

    internal void HideDialog(string charaterID, string content)
    {
        if (!dialogBoxs.ContainsKey(charaterID))
        {
            Debug.LogError("CharaterID key is not existed");
            return;
        }
        dialogBoxs[charaterID].HideDialog();
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
