using System.Collections;
using UnityEngine;

namespace Snoweve.GazeInteraction
{
    public class CameraFovSystem : MonoBehaviour
    {
        public static CameraFovSystem Instance;
        public int fovOriginalIndex = 60;
        public int fovMaxIndex = 10;
        public float zoomSpeed = 10f;
        private Camera _camera;
    
        private void Awake()
        {
            Instance = this;
        }
    
        private void Start()
        {
            _camera = Camera.main;
        }

        public void ZoomIn()
        {
            StartCoroutine(ZoomInIng());
        }
    
        public void ZoomOut()
        {
            StartCoroutine(ZoomOutIng());
        }
    
        private IEnumerator ZoomInIng()
        {
            while (_camera.fieldOfView > fovMaxIndex)
            {
                _camera.fieldOfView -= zoomSpeed*Time.deltaTime;
                yield return null;
            }
        }
    
        private IEnumerator ZoomOutIng()
        {
            while (_camera.fieldOfView < fovOriginalIndex)
            {
                _camera.fieldOfView += zoomSpeed*Time.deltaTime;
                yield return null;
            }
        }
    }
}