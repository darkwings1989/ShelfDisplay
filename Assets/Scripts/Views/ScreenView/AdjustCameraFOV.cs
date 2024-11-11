using System;
using UnityEngine;
using UnityEngine.Events;

namespace ShelfDisplay
{
    public class AdjustCameraFOV : MonoBehaviour
    {
        // A reference to the main camera.
        private Camera mainCamera;
        
        // This timer will record time for every interval.
        private float m_Timer = 0f;
        
        // The interval in seconds (not a const to leave an option to change if it will be needed with a
        // setter method).
        private float m_Interval = 0.3f;
        
        private void Start()
        {
            mainCamera = Camera.main;

            if (mainCamera == null)
            {
                Debug.LogError("Main camera didn't find in the scene, make sure you have camera with MainCamera tag!");
            }
            
            FindAspectRatioAndUpdateCameraFOV();
        }

        void Update()
        {
            FindAspectRatioAndUpdateCameraFOV();
        }
        
        /// <summary>
        /// Find the screen aspect ratio and update the camera fov respectively.
        /// </summary>
        private void FindAspectRatioAndUpdateCameraFOV()
        {
            UpdateFOVEverySecond(() =>
            {
                float screenAspectRatio = GetScreenAspectRatio();
                AdjustCameraFieldOfView(screenAspectRatio);
            });
        }
        
        /// <summary>
        /// Update the camera fov with an action.
        /// </summary>
        /// <param name="action">This action will be invoked every interval of time.</param>
        private void UpdateFOVEverySecond(UnityAction action)
        {
            m_Timer += Time.deltaTime;
            
            // Check if the timer has reached or exceeded the interval time.
            if (m_Timer >= m_Interval)
            {
                action.Invoke();
                // Reseting the timer after it reached or exceeded the interval time.
                m_Timer = 0f;
            }
        }
        
        /// <summary>
        /// Calculate the aspect ratio and return it.
        /// </summary>
        private float GetScreenAspectRatio()
        {
            // Calculate and return the screen aspect ratio.
            return (float)Screen.width / Screen.height;
        }
        
        /// <summary>
        /// This method will adjust the camera field of view to 120 or 75, depends on the aspect ratio value.
        /// </summary>
        /// <param name="aspectRatio"></param>
        private void AdjustCameraFieldOfView(float aspectRatio)
        {
            if (mainCamera == null)
            {
                return;
            }
            
            // If screen in a portrait mode set fov of 118. 
            if (aspectRatio < 1f)
            {
                mainCamera.fieldOfView = 118f;
            }
            else // if screen in a landscape set fov of 45.
            {
                mainCamera.fieldOfView = 45f;
            }
        }
    }
}