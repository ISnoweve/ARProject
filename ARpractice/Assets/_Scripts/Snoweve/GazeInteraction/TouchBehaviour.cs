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
        public string content;

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
                DialogueSystem.instance.StartDialog(content);
                Debug.Log("Right Item Clicked");
                canClick = false;
                QuadTouchBehaviour.Instance.SetActive(true);
            }
            else
            {
                //WrongItem Click Function
                DialogueSystem.instance.StartDialog(content);
                canClick = false;
                QuadTouchBehaviour.Instance.SetActive(true);
            }
        }

        public void OnClickWithLongTap()
        {
            //
        }
    }
}
