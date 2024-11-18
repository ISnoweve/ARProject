using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficalAnisControl : MonoBehaviour
{
    public TeleControl teleControl;
    public WellCtr wellCtr;
    public InOutPortalRender offical;
    public InOutPortalRender localOffical;
    public void OpenTele()
    {
        teleControl.PortalApper();
    }

    public void CloseTele()
    {
        teleControl.PortalDisapper();
    }

    public void WellApper()
    {
        wellCtr.ShowWell();
       LeanTween.delayedCall(1,()=> wellCtr.ShowWater());
    }

    public void WellDisapper()
    {
        wellCtr.HideWell();
    }

    public void OutPortal()
    {
        offical.OutPortal();
        localOffical.OutPortal();
    }

    public void OfficalDisapper()
    {
        offical.Disapper();
        localOffical.Disapper();
    }

    public void DebugTest()
    {
        Debug.Log("test");
    }
}
