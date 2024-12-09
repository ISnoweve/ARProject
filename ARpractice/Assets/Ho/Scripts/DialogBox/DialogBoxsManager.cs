using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[DefaultExecutionOrder(-2)]
public class DialogBoxsManager : MonoBehaviour
{
    internal static DialogBoxsManager instance;
    private Dictionary<string, DialogBoxCtr> dialogBoxs = new();
    private void Awake()
    {
        instance = this;
    }

    private void OnEnable()
    {
        DialogueSystem.OnDialogueSet += ShowDialog; 
    }


    private void OnDisable()
    {
        DialogueSystem.OnDialogueSet -= ShowDialog;
    }

    internal void ShowDialog(string charaterID,string content)
    {
        Debug.Log(charaterID);
        Debug.Log(content);
        if (!dialogBoxs.ContainsKey(charaterID))
        {
            Debug.LogError("Charater " + charaterID +" is not existed");
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

    public void AddDialogBox(DialogBoxCtr dialogBoxCtr)
    {
        if (dialogBoxs.ContainsKey(dialogBoxCtr.charaterID))
        {
            Debug.LogError("Same dialogBox key is existed");
            return;
        }
        dialogBoxs.Add(dialogBoxCtr.charaterID, dialogBoxCtr);
        Debug.Log("Added");
    }
    public void DelectDialogBox(string charaterID)
    {
        if (!dialogBoxs.ContainsKey(charaterID))
        {
           return;
        }
        dialogBoxs.Remove(charaterID);
        Debug.Log("Removed");
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
