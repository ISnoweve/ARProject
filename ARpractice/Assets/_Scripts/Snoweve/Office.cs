public class Office : ARObjectBehaviour
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

    private void SpawnOfficeAfterBoatMove(string id, string animationName)
    {
        if (id == "Boat" && animationName == "BoatMove")
        {

        }
    }
    
    private void DeSpawnOfficeAfterDialog(string id, string animationName)
    {
        if (id == "Boat" && animationName == "BoatMove")
        {
            OnDeSpawn();
        }
    }
}