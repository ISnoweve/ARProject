using UnityEngine;
using UnityEngine.UI;

namespace Snoweve.GazeInteraction
{
    public class GazeInteraction : MonoBehaviour
    {
        public Slider detectionSlider;
        public float observationTime = 5.0f; 
        public float detectionTime = 0.0f;
        [SerializeField] private bool isDetected = false;
        [SerializeField] private GazeObject gazeObject;
    

        private void Awake()
        {
            detectionSlider.gameObject.SetActive(false);
        }

        void Update()
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                if (hit.collider.GetComponent<GazeObject>() != null && !isDetected)
                {
                    Debug.Log("Gaze Detected");
                    gazeObject = hit.collider.GetComponent<GazeObject>();
                    detectionSlider.gameObject.SetActive(true);
                    detectionSlider.value = detectionTime / observationTime;
                    detectionTime += Time.deltaTime;
                    if(detectionTime >= observationTime) 
                    { 
                        detectionSlider.gameObject.SetActive(false);
                        isDetected = true;
                        gazeObject.OnGaze();
                    }
                }
            }
            else
            {
                detectionSlider.gameObject.SetActive(false);
                detectionTime = 0.0f;
                detectionSlider.value = 0.0f;
            }
        }
        

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(transform.position, transform.forward * 100);
        }
    }
}
