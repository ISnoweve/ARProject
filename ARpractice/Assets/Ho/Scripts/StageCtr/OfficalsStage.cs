using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficalsStage : MonoBehaviour
{
    public void StartIntro()
    {
        DialogueSystem.instance.StartDialog("±µ©x_1");
    }

    public void ShinInDialog()
    {
        DialogueSystem.instance.StartDialog("±µ©x_2");
    }

    public void OfficalsDialog()
    {
        DialogueSystem.instance.StartDialog("±µ©x_3");
    }
}
