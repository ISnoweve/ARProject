using UnityEngine;
using UnityEngine.UI;

namespace ObjectTestScaleFeature
{
    public class ARObjectControl : MonoBehaviour
    {
        public Scrollbar scrollbarForScale;
        public Text scaleText;
        private Transform _objectTransform;
        private Vector3 _originalScale;
        

        private void Awake()
        {
            _objectTransform = GetComponent<Transform>();
            _originalScale = _objectTransform.localScale;
        }

        private void Start()
        {
            ArPlaneCtr.Instance.StopMarkingGroundEvent += DisplayARObject;
            ArPlaneCtr.Instance.MarkingGroundEvent += UnDisplayARObject;
        }

        public void ChangeScale()
        {
            if(scrollbarForScale.value<=0.01)
                scrollbarForScale.value = 0.01f;
            
            _objectTransform.localScale = new Vector3(
                _originalScale.x*scrollbarForScale.value, 
                _originalScale.y*scrollbarForScale.value, 
                _originalScale.z*scrollbarForScale.value);
                
            scaleText.text = $"Scale: {_objectTransform.localScale.x}";
        }

        private void DisplayARObject(Transform objTransform)
        {
            _objectTransform.gameObject.SetActive(true);
            _objectTransform.position = objTransform.position;
            _objectTransform.rotation = objTransform.rotation;
            scrollbarForScale.gameObject.SetActive(true);
            scaleText.transform.gameObject.SetActive(true);
        }

        private void UnDisplayARObject()
        {
            _objectTransform.gameObject.SetActive(false);
            scrollbarForScale.gameObject.SetActive(false);
            scaleText.transform.gameObject.SetActive(false);
        }
    }
}