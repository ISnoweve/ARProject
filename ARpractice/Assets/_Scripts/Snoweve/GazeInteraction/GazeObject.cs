using System;
using General.Interface;
using UnityEngine;

namespace Snoweve.GazeInteraction
{
    public class GazeObject : MonoBehaviour 
    {
        public TouchBehaviour touchBehaviour;

        [Header("If there is no TouchBehaviour, write this parameter")]
		public bool noItem;
        public string content;

        public void OnGaze()
        {
            CameraFovSystem.Instance.ZoomIn();
            if (noItem)
            {
                //NoItem Click Function
                DialogueSystem.instance.StartDialog(content);
                QuadTouchBehaviour.Instance.SetActive(true);
                return;
            }
            touchBehaviour.canClick = true;
        }
    }
}
