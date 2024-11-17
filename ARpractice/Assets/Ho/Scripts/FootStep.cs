using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class FootStep : MonoBehaviour
{
    public VisualEffect footVFX;

    private void Update()
    {
        footVFX.SetVector3("Rotation", transform.localRotation.eulerAngles);
    }
}
