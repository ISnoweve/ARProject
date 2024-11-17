using UnityEngine;

public class FootPrint : ARObjectBehaviour
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
        AnimationSystem.Instance.OnAnimationEnd += DestroyFootPrint;
    }

    public override void UnRegisterEvent()
    {
        AnimationSystem.Instance.OnAnimationEnd -= DestroyFootPrint;
    }

    public override void OnAnimationEnd(string animationName)
    {
        throw new System.NotImplementedException();
    }
    
    private void DestroyFootPrint(string id, string animationName)
    {
        if (id == "LittleWell" && animationName == "Spawn")
        {
            OnDeSpawn();
        }
    }
}