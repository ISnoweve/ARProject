using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficalsStage : MonoBehaviour
{
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
}
