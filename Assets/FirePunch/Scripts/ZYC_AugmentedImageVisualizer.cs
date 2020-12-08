namespace GoogleARCore.Examples.AugmentedImage
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using GoogleARCore;
    using GoogleARCoreInternal;
    using UnityEngine;

    /// <summary>
    /// Uses 4 frame corner objects to visualize an AugmentedImage.
    /// </summary>
    public class ZYC_AugmentedImageVisualizer : MonoBehaviour
    {
        /// <summary>
        /// The AugmentedImage to visualize.
        /// </summary>
        public AugmentedImage Image;

        public Dictionary<int, ZYC_AugmentedImageVisualizer> m_Visualizers = null;

        /// <summary>
        /// A model for the lower left corner of the frame to place when an image is detected.
        /// </summary>
        public GameObject item;
        public float TimePassed=0.0f;

        public float angel=30.0f;

        /// <summary>
        /// The Unity Update method.
        /// </summary>
        public bool isOverImage=true;
        private void Start() {
            item=this.transform.GetChild(0).gameObject;
        }
        
        public void Update()
        {
            if(isOverImage){
                OverImage();
            }else{

            }
            
        }

        void OverImage(){
            if (Image == null || Image.TrackingState != TrackingState.Tracking)
            {
                item.SetActive(false);
                return;
            }

            float halfWidth = Image.ExtentX / 2;
            float halfHeight = Image.ExtentZ / 2;
            float xiebian=(float)Mathf.Sqrt(Mathf.Pow(halfWidth,2)+Mathf.Pow(halfHeight,2));
            float height=Mathf.Tan(Mathf.Deg2Rad*angel)*xiebian;
            item.transform.localPosition =(height * Vector3.up);

            item.SetActive(true);
        }

        void OnDestroy()
        {
            m_Visualizers.Remove(Image.DatabaseIndex);
        }
    }
}
