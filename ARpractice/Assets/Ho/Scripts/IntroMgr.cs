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
        Hints.instance.Show("��X���P�ĸ�����m�ù�ǨӶi�汴��");
        foreach (var intro in intros)
        {
            intro.EnableInteract();
        }
    }
}
