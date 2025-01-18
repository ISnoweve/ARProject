using System;
using General.Interface;
using UnityEngine;

namespace Snoweve.GazeInteraction
{
    public class GazeObject : MonoBehaviour 
    {
        public TouchBehaviour touchBehaviour;

        [Header("If there is no TouchBehaviour, write this parameter")]
        public string dialogueID;

        public void OnGaze()
        {
            CameraFovSystem.Instance.ZoomIn();
            if (touchBehaviour == null)
            {
                //NoItem Click Function
                DialogBoxsManager.instance.ShowDialog(dialogueID, "");
                QuadTouchBehaviour.Instance.gameObject.SetActive(true);
                return;
            }
            touchBehaviour.canClick = true;
        }
    }
}
