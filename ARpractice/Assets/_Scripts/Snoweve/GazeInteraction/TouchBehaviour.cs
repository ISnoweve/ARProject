using General.Interface;
using UnityEngine;

namespace Snoweve.GazeInteraction
{
    public class TouchBehaviour : MonoBehaviour, IClickable
    {
        public void OnClick()
        {
            Debug.LogError("Click");
        }

        public void OnClickWithLongTap()
        {
            //
        }
    }
}
