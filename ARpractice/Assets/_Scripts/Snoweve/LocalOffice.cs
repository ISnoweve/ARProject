﻿public class LocalOffice : ARObjectBehaviour
{
    
    public override void OnSpawn()
    {
        gameObject.SetActive(true);
        RegisterSystem();
        RegisterEvent();
    }

    public override void OnDeSpawn()
    {
        UnRegisterSystem();
        UnRegisterEvent();
        gameObject.SetActive(false);
    }

    public override void RegisterSystem()
    {
        AnimationSystem.Instance.RegisterDictionary(id, animator);
    }

    public override void UnRegisterSystem()
    {
        AnimationSystem.Instance.UnRegisterDictionary(id);
    }

    public override void RegisterEvent()
    {
        throw new System.NotImplementedException();
    }

    public override void UnRegisterEvent()
    {
        throw new System.NotImplementedException();
    }
    
    public override void OnAnimationEnd(string animationName)
    {
        AnimationSystem.Instance.CallAnimationEnd(id, animationName);
    }
    
    private void SpawnLocalOfficeAfterPaperSpawn(string id, string animationName)
    {
        if (id == "Paper" && animationName == "PaperSpawn")
        {
            OnSpawn();
        }
    }
    
    private void DeSpawnLocalOfficeAfterDialog(string id, string animationName)
    {
        if (id == "Boat" && animationName == "BoatMove")
        {
            OnDeSpawn();
        }
    }
}