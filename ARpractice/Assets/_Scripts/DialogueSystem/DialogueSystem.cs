using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    #region Singleton
    public static DialogueSystem instance { get; private set; }

    private void InitSingleton()
    {
        // Only keep oldest one to keep tracking loaded dialogues.
        if (instance == null)
        { instance = this; DontDestroyOnLoad(gameObject); }
        else
        { Destroy(gameObject); }
    }
    #endregion

    [SerializeField] private TextAsset textScript;

    public Dictionary<string, int> sectionDictionary { get; private set; } = new();
    public int currentIndex { get; private set; } = -1;

    private readonly Regex regex = new(@"^\[(?<EventTag>\w+)(?>\:(?<Settings>[\w\d,]*))?\](?<Content>.+)?", RegexOptions.Multiline);
    private List<Dialogue> dialogues = new();
    
    public delegate void DialogueDelegate(string chara, string content);
    public static event DialogueDelegate StartAnimation;
    public static event DialogueDelegate OnDialogueSet;

    public delegate void DialogueEndDelegate();
    public static event DialogueEndDelegate OnDialogueFinish;

    private string currentCharactor = string.Empty;

    private void Initialize()
    {
        // Load text script to collection
        LoadTextScript();

    }

    private void Awake()
    {
        InitSingleton();
        Initialize();
    }

    private void LoadTextScript()
    {
        // Prevent issue with hot reload.
        sectionDictionary.Clear();
        dialogues.Clear();

        var matches = regex.Matches(textScript.text);
        foreach(Match match in matches)
        {
            switch (match.Groups["EventTag"].Value)
            {
                case "Start":
                    try
                    {
                        sectionDictionary.Add(match.Groups["Settings"].Value, dialogues.Count - 1);
                    }
                    catch (ArgumentException)
                    {
                        Debug.LogWarning("Maker name: " + match.Groups["Settings"].Value + " already exists.");
                    }
                    break;
                default:
                    dialogues.Add(new Dialogue(
                        match.Groups["EventTag"].Value,
                        match.Groups["Settings"].Value.Split(','),
                        match.Groups["Content"].Value.Replace("\\n", "\n")
                        ));
                    break;
            }
        }

        Debug.Log($"{matches.Count} contents has been found. There're {dialogues.Count} dialouges.");
    }

    public int StartDialog(string dialogKey)
    {
        return SetDialog(sectionDictionary[dialogKey]);
    }

    public int StartDialog(int dialogIndex)
    {
        return SetDialog(dialogIndex);
    }

    public int NextDialog()
    {
        return SetDialog(SetDialog(currentIndex + 1));
    }

    public int SetDialog(int dialogIndex)
    {
        currentIndex = dialogIndex;

        var dialog = dialogues[currentIndex];

        switch (dialog.tag)
        {
            case "Ani":
                currentCharactor = dialog.setting[0];
                Debug.Log("Ani");
                StartAnimation?.Invoke(currentCharactor, dialog.setting[1]);
                break;

            case "Dialog":
                // Trigger animation event
                OnDialogueSet?.Invoke(currentCharactor, dialog.content);
                Debug.Log("Dialog");
                float _duration;
                if (!float.TryParse(dialog.setting[0], out _duration))
                { Debug.LogWarning($"Dialouge duration is not defined !"); break; }

                LeanTween.delayedCall(_duration, () => {
                    NextDialog();
                    OnDialogueFinish?.Invoke();
                });
                break;
        }

        return currentIndex;
    }


}

[System.Serializable]
public struct Dialogue
{
    public string tag;
    public string[] setting;
    public string content;

    public Dialogue(string tag, string[] setting = null, string content = null)
    {
        this.tag = tag;
        this.setting = setting;
        this.content = content;
    }
}
