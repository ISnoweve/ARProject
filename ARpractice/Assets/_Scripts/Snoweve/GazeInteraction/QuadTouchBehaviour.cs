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
            CameraFovSystem.Instance.ZoomOut();
            gameObject.SetActive(false);
        }

        public void OnClickWithLongTap()
        {
            throw new System.NotImplementedException();
        }
    }
}
