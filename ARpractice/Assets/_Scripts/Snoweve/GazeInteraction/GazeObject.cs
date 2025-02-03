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
           // CameraFovSystem.Instance.ZoomIn();
            if (noItem)
            {
                //NoItem Click Function
                DialogueSystem.instance.StartDialog(content);
                Debug.Log("NoItem");
                //QuadTouchBehaviour.Instance.SetActive(true);
                AndriodInput.instance.OnTouch += Touch;
                return;
            }
            touchBehaviour.canClick = true;
            touchBehaviour.OnClick();
            
        }


        public void Touch()
        {
            if (CameraFovSystem.Instance.isZooming) return;
           // CameraFovSystem.Instance.ZoomOut();
            DialogueSystem.instance.NextDialog();
            AndriodInput.instance.OnTouch -= Touch;
            GazeInteraction.Instance.ResetDetection();
            if(QuadTouchBehaviour.Instance.touchBehaviour != null)
            {
                QuadTouchBehaviour.Instance.touchBehaviour.gameFinish.Invoke();
            }
        }
    }
}
