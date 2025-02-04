using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroMgr : MonoBehaviour
{
    public IntroObject[] intros;



    public void EnableIntros()
    {
        Hints.instance.Show("對準有感嘆號的位置進行探索");
        foreach (var intro in intros)
        {
            intro.EnableInteract();
        }
    }
}
