using System;
using General.Interface;
using UnityEngine;

namespace Snoweve.GazeInteraction
{
    public class QuadTouchBehaviour : MonoBehaviour, IClickable
    {
        public static QuadTouchBehaviour Instance;
        public bool canZoom;

        public void Awake()
        {
            Instance = this;
            gameObject.SetActive(false);
        }

        public void OnClick()
        {
            if(CameraFovSystem.Instance.isZooming)return;
            CameraFovSystem.Instance.ZoomOut();
            SetActive(false);
        }

        public void OnClickWithLongTap()
        {
            throw new System.NotImplementedException();
        }
        
        public void SetActive(bool active)
        {
            gameObject.SetActive(active);
            if(active)return;
            GazeInteraction.Instance.ResetDetection();
        }
    }
}
