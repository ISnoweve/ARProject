using System.IO;
using PictureFeature.Data;
using PictureFeature.Interface;
using UnityEngine;

namespace PictureFeature
{
    public class PictureSystem : MonoBehaviour
    {
        public static PictureSystem Instance;
        public PictureScriptableObjectList pictureScriptableObjectList;
        public PictureBehaviour pictureBehaviour;
        public PictureTransparency pictureTransparency;
        private Camera _cameraToCapture;
        public int imageWidth = 1920;
        public int imageHeight = 1080;
        public string saveName = "CapturedImage.png";
        public int detectionRadius;
        
        private void Awake()
        {
            Instance = this;
            pictureScriptableObjectList = Resources.Load<PictureScriptableObjectList>("PictureScriptableObjectList/PictureScriptableObjectList");
            pictureBehaviour = FindObjectOfType<PictureBehaviour>();
            pictureTransparency.gameObject.SetActive(false);
            pictureBehaviour.Initialize();
            //pictureBehaviour.OnSpawn(pictureScriptableObjectList.pictureScriptableObjects[0]);
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                CaptureImage();
            }
        }
        
        #region TakePhotoFeature
        public void CaptureImage()
        {            
            _cameraToCapture = Camera.main;
            var savePath = Path.Combine(Application.streamingAssetsPath, saveName);

            //對整個相機內的畫面進行掃描，檢測是否有實現 IPicture 接口的物體
            DetectObjectsInView();
            // 創建 Render Texture
            RenderTexture renderTexture = new RenderTexture(imageWidth, imageHeight, 24);
            _cameraToCapture.targetTexture = renderTexture;
            _cameraToCapture.Render();

            // 創建新的 Texture2D
            Texture2D texture = new Texture2D(imageWidth, imageHeight, TextureFormat.RGB24, false);
            RenderTexture.active = renderTexture;
            texture.ReadPixels(new Rect(0, 0, imageWidth, imageHeight), 0, 0);
            texture.Apply();

            // 重置相機的目標紋理和 RenderTexture
            _cameraToCapture.targetTexture = null;
            RenderTexture.active = null;
            Destroy(renderTexture);

            // 將紋理編碼為 PNG
            byte[] bytes = texture.EncodeToPNG();
            File.WriteAllBytes(savePath, bytes);

            Debug.Log("Image saved to " + savePath);
        }

        private void DetectObjectsInView()
        {
            Collider[] hitColliders = Physics.OverlapSphere(_cameraToCapture.transform.position, detectionRadius);
            foreach (var hitCollider in hitColliders)
            {
                IPicture pictureComponent = hitCollider.GetComponent<IPicture>();
                if (pictureComponent != null)
                {
                    Debug.Log("Detected " + hitCollider.name + " objects in view");
                    pictureComponent.OnTakePhoto();
                }
            }
        }

        #endregion
        
        public void GeneratePictureObject(Sprite sprite)
        {
            Debug.Log("Generate Picture Object");

            foreach (var VARIABLE in pictureScriptableObjectList.pictureScriptableObjects)
            {
                if (VARIABLE.pictureSprite == sprite)
                { 
                    Debug.Log(VARIABLE.pictureSprite.name);
                    foreach (var variable in VARIABLE.inPictureObjects)
                    {
                        var camera = Camera.main;
                        var pictureObject = Instantiate(variable.pictureObject, default, variable.rotation,transform);
                        pictureObject.GetComponent<PictureObjectBaseBehaviour>().RestoreRelativeTransform(variable.cameraPictureRelativePosition, variable.rotation);
                    }
                }
            }
            
        }

        public void SpawnPicture(PictureScriptableObject pictureScriptableObject)
        {
            pictureTransparency.gameObject.SetActive(true);
            pictureBehaviour.OnSpawn(pictureScriptableObject);
        }
        
        public void CallBackPicture()
        {
            pictureTransparency.gameObject.SetActive(false);
            pictureBehaviour.DeSpawn();
        }
    }
}