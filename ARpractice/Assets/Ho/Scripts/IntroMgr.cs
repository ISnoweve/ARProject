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
        Hints.instance.Show("對準有圓點的位置來進行探索");
        foreach (var intro in intros)
        {
            intro.EnableInteract();
        }
    }
}
