using System;
using General.Interface;
using UnityEngine;

public class MissonBehaviour : MonoBehaviour , IClickable
{
    public bool canTouch = true;
    public void OnClick()
    {
        if (!canTouch)return;
        HandControl.instance.GetMissionBehaviour(this);
    }

    public void OnClickWithLongTap()
    {
        throw new System.NotImplementedException();
    }

    private void Awake()
    {
        canTouch = true;
    }
}
