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
        
        public void RestoreRelativeTransform(Vector3 relativePosition, Quaternion rotation, bool isRayHit = false, float rayLength = 0f)
        {
            Camera camera = Camera.main;
            transform.position = camera.transform.rotation * relativePosition + camera.transform.position;
            transform.rotation = camera.transform.rotation * rotation;

            if (!isRayHit) return;
            var scaleRatio = Mathf.Clamp01(rayLength / relativePosition.magnitude);
            transform.position = Vector3.Lerp(camera.transform.position, transform.position, scaleRatio);
            transform.localScale *= scaleRatio;
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