using System;
using General.Interface;
using UnityEngine;

namespace Snoweve.GazeInteraction
{
    public class GazeObject : MonoBehaviour , IClickable
    {
        public string dialogueID;
        public bool canClick;
        private bool _isRightClick;

        public void OnClick()
        {
            if(!canClick)return;
            OpenDialog();
        }

        public void OnClickWithLongTap()
        {
            //
        }
        
        public void OpenDialog()
        {
            if (_isRightClick)
            {
                //Game Over
            }
            else
            {
                DialogBoxsManager.instance.ShowDialog(dialogueID, "");
            }
        }
        
        public void CloseDialog()
        {
            DialogBoxsManager.instance.HideDialog(dialogueID);
        }
    }
}
