using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroMgr : MonoBehaviour
{
    public IntroObject[] intros;



    public void EnableIntros()
    {
        Hints.instance.Show("��Ǧ��P�ĸ�����m�i�汴��");
        foreach (var intro in intros)
        {
            intro.EnableInteract();
        }
    }
}
