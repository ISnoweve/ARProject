
public class SmallBrick : ARObjectBehaviour
{
    
    public override void OnSpawn()
    {
        RegisterSystem();
        RegisterEvent();
        AnimationSystem.Instance.PlayAnimation(id, "Idle");
    }

    public override void OnDeSpawn()
    {
        UnRegisterSystem();
        UnRegisterEvent();
        ARObjectSpawnSystem.Instance.DeSpawnObject(this);
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
    }

    public override void UnRegisterEvent()
    {
        throw new System.NotImplementedException();
    }

    public override void OnAnimation(string animationName)
    {
        
    }
    
    public override void OnDialog(string dialogId)
    {
        
    }
    
    public override void OnVoice(string voiceId)
    {
        
    }

    public override void OnAnimationEnd(string animationName)
    {
        AnimationSystem.Instance.AnimationEnd(id, animationName);
    }
}
