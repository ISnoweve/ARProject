using System;
using General.Interface;
using UnityEngine;

namespace Snoweve.GazeInteraction
{
    public class GazeObject : MonoBehaviour , IClickable
    {
        public bool canClick;
        public bool isRightClick;
        public InfoBehaviour infoBehaviour;

        private void Awake()
        {
            infoBehaviour.gameObject.SetActive(false);
        }

        public void OnClick()
        {
            if(!canClick)return;
            if (isRightClick)
            {
                
            }
            else
            {
                infoBehaviour.gameObject.SetActive(true);
            }
        }

        public void OnClickWithLongTap()
        {
            //
        }
        
        public void CloseInfo()
        {
            infoBehaviour.gameObject.SetActive(false);
        }
    }
}
