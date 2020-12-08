﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoogleARCore.Examples.AugmentedImage
{
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using GoogleARCore;
    using UnityEngine;
    using UnityEngine.UI;
    // Start is called before the first frame update
    /// <summary>
    /// Controller for AugmentedImage example.
    /// </summary>
    /// <remarks>
    /// In this sample, we assume all images are static or moving slowly with
    /// a large occupation of the screen. If the target is actively moving,
    /// we recommend to check <see cref="AugmentedImage.TrackingMethod"/> and
    /// render only when the tracking method equals to
    /// <see cref="AugmentedImageTrackingMethod"/>.<c>FullTracking</c>.
    /// See details in <a href="https://developers.google.com/ar/develop/c/augmented-images/">
    /// Recognize and Augment Images</a>
    /// </remarks>
    public class ZYC_AugmentedImageExampleController : MonoBehaviour
    {
        /// <summary>
        /// A prefab for visualizing an AugmentedImage.
        /// </summary>
        public ZYC_AugmentedImageVisualizer[] AugmentedImageVisualizerPrefabs;

        /// <summary>
        /// The overlay containing the fit to scan user guide.
        /// </summary>
        public GameObject FitToScanOverlay;

        private Dictionary<int, ZYC_AugmentedImageVisualizer> m_Visualizers
            = new Dictionary<int, ZYC_AugmentedImageVisualizer>();

        private List<AugmentedImage> m_TempAugmentedImages = new List<AugmentedImage>();

        /// <summary>
        /// The Unity Awake() method.
        /// </summary>
        public void Awake()
        {
            // Enable ARCore to target 60fps camera capture frame rate on supported devices.
            // Note, Application.targetFrameRate is ignored when QualitySettings.vSyncCount != 0.
            Application.targetFrameRate = 60;
        }

        /// <summary>
        /// The Unity Update method.
        /// </summary>
        public void Update()
        {
            // Exit the app when the 'back' button is pressed.
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }

            // Only allow the screen to sleep when not tracking.
            if (Session.Status != SessionStatus.Tracking)
            {
                Screen.sleepTimeout = SleepTimeout.SystemSetting;
            }
            else
            {
                Screen.sleepTimeout = SleepTimeout.NeverSleep;
            }

            // Get updated augmented images for this frame.
            Session.GetTrackables<AugmentedImage>(
                m_TempAugmentedImages, TrackableQueryFilter.Updated);

            // Create visualizers and anchors for updated augmented images that are tracking and do
            // not previously have a visualizer. Remove visualizers for stopped images.
            foreach (var image in m_TempAugmentedImages)
            {
                ZYC_AugmentedImageVisualizer visualizer = null;
                m_Visualizers.TryGetValue(image.DatabaseIndex, out visualizer);
                if (image.TrackingState == TrackingState.Tracking && visualizer == null)
                {
                    // Create an anchor to ensure that ARCore keeps tracking this augmented image.
                    Anchor anchor = image.CreateAnchor(image.CenterPose);
                    if(image.Name=="P49_1"){
                        visualizer = (ZYC_AugmentedImageVisualizer)Instantiate(
                        AugmentedImageVisualizerPrefabs[0], anchor.transform);
                    }else if(image.Name=="P52_1"){
                        visualizer = (ZYC_AugmentedImageVisualizer)Instantiate(
                        AugmentedImageVisualizerPrefabs[1], anchor.transform);
                    }else{
                        visualizer = (ZYC_AugmentedImageVisualizer)Instantiate(
                        AugmentedImageVisualizerPrefabs[2], anchor.transform);
                        visualizer.gameObject.name=image.Name;
                    }
                    visualizer.Image = image;
                    visualizer.m_Visualizers=m_Visualizers;
                    m_Visualizers.Add(image.DatabaseIndex, visualizer);
                }
                /*
                else if ((image.TrackingState == TrackingState.Stopped) && visualizer != null)
                {
                    m_Visualizers.Remove(image.DatabaseIndex);
                    GameObject.Destroy(visualizer.gameObject);
                }
                */
                
            }

            // Show the fit-to-scan overlay if there are no images that are Tracking.
            foreach (var visualizer in m_Visualizers.Values)
             {
                if (visualizer.Image.TrackingState == TrackingState.Tracking)
                {
                    FitToScanOverlay.SetActive(false);
                    return;
                }
            }

            FitToScanOverlay.SetActive(true);
        }
    }
}
