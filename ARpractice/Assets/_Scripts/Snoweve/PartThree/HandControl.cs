using System;
using Unity.VisualScripting;
using UnityEngine;

public class HandControl : MonoBehaviour
{
    public static HandControl instance;
    public MissonBehaviour missionBehaviour;
    public NPCBehaviour Npc;
    public bool isHandActive;
    
    private void Awake()
    {
        instance = this;
        isHandActive = false;
    }

    public void GetMissionBehaviour(MissonBehaviour misson)
    {
        if(isHandActive)return;
        missionBehaviour = misson;
        isHandActive = true;
        misson.canTouch = false;
        misson.gameObject.transform.SetParent(Camera.main.transform);
        misson.gameObject.transform.localPosition = new Vector3(0.4f, -0.5f, 1f);
        misson.gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }
    
    public MissonBehaviour GetMissionBehaviour()
    {
        return isHandActive ? missionBehaviour : null;
    }

    public void CompleteMission()
    {
        missionBehaviour.gameObject.SetActive(false);
        missionBehaviour = null;
        isHandActive = false;
    }
}
