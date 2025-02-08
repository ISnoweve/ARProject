using System.Collections;
using System.Collections.Generic;
using Snoweve.GazeInteraction;
using UnityEngine;

public class IntroMgr : MonoBehaviour
{
    public IntroObject[] intros;



    public void EnableIntros()
    {
        GazeInteraction.Instance.isDetected = false;
        Hints.instance.Show("��Ǧ����I����m�Ӷi�汴��");
        foreach (var intro in intros)
        {
            intro.EnableInteract();
        }
    }
}
