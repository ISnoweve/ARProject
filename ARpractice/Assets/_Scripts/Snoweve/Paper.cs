using UnityEngine;

public class Paper : ARObjectBehaviour
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
        AnimationSystem.Instance.OnAnimationEnd += SpawnPaperAfterDialogOne;
    }

    public override void UnRegisterEvent()
    {
        AnimationSystem.Instance.OnAnimationEnd -= SpawnPaperAfterDialogOne;
    }

    public override void OnAnimationEnd(string animationName)
    {
        AnimationSystem.Instance.CallAnimationEnd(id, animationName);
    }

    private void SpawnPaperAfterDialogOne(string id, string animationName)
    {
        if (id == "LittleWell" && animationName == "DialogOne")
        {
            OnSpawn();
            AnimationSystem.Instance.PlayAnimation("Paper","PaperSpawn");
        }
    }
}