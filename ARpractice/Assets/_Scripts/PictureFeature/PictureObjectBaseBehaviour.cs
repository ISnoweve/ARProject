using General.Interface;
using PictureFeature.Interface;
using UnityEngine;

namespace PictureFeature
{
    public class PictureObjectBaseBehaviour : MonoBehaviour,IPicture, IClickable
    {
        public void OnTakePhoto()
        {
            var camera = Camera.main;
            Debug.Log($"Camera{Quaternion.Inverse(camera.transform.rotation)*(transform.position - camera.transform.position)}");
            Debug.Log(Quaternion.Inverse(camera.transform.rotation)*transform.rotation);
        }
        
        public void RestoreRelativeTransform(Vector3 relativePosition, Quaternion rotation)
        {
            Camera camera = Camera.main;
            transform.position = camera.transform.rotation * relativePosition + camera.transform.position;
            transform.rotation = camera.transform.rotation * rotation;
        }
        
        public void OnClick()
        {
            
        }

        public void OnClickWithLongTap()
        {
            throw new System.NotImplementedException();
        }
    }
}