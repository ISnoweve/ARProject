using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeStage : MonoBehaviour
{
    public WellsCtr wellsCtr;
    public TeleControl teleControl;
    public float TimeBeforeTeleApper = 10;
    

    [ContextMenu("WellIntro")]
    public void WellIntro()
    {
        wellsCtr.OutWellApper();
        LeanTween.delayedCall(4, () => DialogueSystem.instance.StartDialog("TempleStart"));
        LeanTween.delayedCall(TimeBeforeTeleApper, () => teleControl.PortalApper());
    }
}
