using System;
using General.Interface;
using UnityEngine;

namespace Snoweve.GazeInteraction
{
    public class TouchBehaviour : MonoBehaviour, IClickable
    {
        public string dialogueID;
        public bool canClick;
        public bool isRightObjectToClick;

        private void Awake()
        {
            canClick = false;
        }

        public void OnClick()
        {
            if(!canClick)return;
            if (isRightObjectToClick)
            {
                //RightItem Click Function
                DialogBoxsManager.instance.ShowDialog(dialogueID, "");
                canClick = false;
                QuadTouchBehaviour.Instance.gameObject.SetActive(true);
            }
            else
            {
                //WrongItem Click Function
                DialogBoxsManager.instance.ShowDialog(dialogueID, "");
                canClick = false;
                QuadTouchBehaviour.Instance.gameObject.SetActive(true);
            }
        }

        public void OnClickWithLongTap()
        {
            //
        }
    }
}
