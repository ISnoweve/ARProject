using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficalsStage : MonoBehaviour
{

    public OfficalAnisControl officalAnisControl;

    public void StartIntro()
    {
        DialogueSystem.instance.StartDialog("���x_1");
    }

    public void ShinInDialog()
    {
        DialogueSystem.instance.StartDialog("���x_2");
    }

    public void OfficalsDialog()
    {
        DialogueSystem.instance.StartDialog("���x_3");
    }

    public void AfterOfficalsOutDialog()
    {
        officalAnisControl.WellApper();
        LeanTween.delayedCall(0.5f,()=> DialogueSystem.instance.StartDialog("���x_4"));
        DialogueSystem.onSectionEnd += officalAnisControl.WellDisapper;
        DialogueSystem.onSectionEnd += ()=> DialogueSystem.onSectionEnd-=officalAnisControl.WellDisapper;

    }
}
