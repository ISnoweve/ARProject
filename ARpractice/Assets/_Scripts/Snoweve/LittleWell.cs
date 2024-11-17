
using UnityEngine;

public class LittleWell : ARObjectBehaviour
{

    public override void OnSpawn()
    {
        gameObject.SetActive(true);
        RegisterSystem();
        RegisterEvent();
        SpawnLittleWell();
    }

    public override void OnDeSpawn()
    {
        UnRegisterSystem();
        UnRegisterEvent();
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

    public override void OnAnimationEnd(string animationName)
    {
        AnimationSystem.Instance.CallAnimationEnd(id, animationName);
    }
    
    private void SpawnLittleWell()
    {
        Debug.Log("Spawn LittleWell");
        AnimationSystem.Instance.PlayAnimation(id, "Spawn");
    }

    private void TalkDialogOne(string id, string animationName)
    {
        if (id == "LittleWell" && animationName == "Spawn")
        {
            // DialogueSystem.Instance.PlayDialog("LittleWell", "DialogOne");
        }
    }
    
    private void TalkDialogTwo(string id, string animationName)
    {
        if (id == "LittleWell" && animationName == "DialogOne")
        {
            // DialogueSystem.Instance.PlayDialog("LittleWell", "DialogTwo");
        }
    }
    
    private void TalkDialogAfterOfficeLeave(string id, string animationName)
    {
        if (id == "LittleWell" && animationName == "DialogTwo")
        {
            // DialogueSystem.Instance.PlayDialog("LittleWell", "DialogThree");
        }
    }
}
