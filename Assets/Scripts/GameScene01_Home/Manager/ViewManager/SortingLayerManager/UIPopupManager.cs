using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace HomeScene.UIPopup
{
    public class UIPopupManager : CanvasBase
    {
        #region Declaration

        [SerializeField]
        private RectTransform cameraScreenSafeArea;

        private static PlayableDirector playableDirector;
        private static Action onTimelineFinishCallback;

        [Header("Popup")]
        public ZoomImagePopup.ZoomImagePopup zoomImagePopup;


        #endregion

        #region Init Stage

        public void InitManager()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            // Init Playable Director
            playableDirector = null;
            onTimelineFinishCallback = null;
        }

        #endregion

        #region Setup Stage

        public void SetupManager(Camera mainCamera, ScreenPropertiesData screenPropertiesData, SortingLayerOption sortingLayerOption)
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            // Setup base
            base.SetupCanvas(mainCamera, screenPropertiesData.cameraScreen, sortingLayerOption);

            // Setup Playable Director
            playableDirector = this.GetComponent<PlayableDirector>();

            // Setup safe area
            cameraScreenSafeArea = base.SetupSafeAreaRectTransform(cameraScreenSafeArea, screenPropertiesData.cameraScreen, screenPropertiesData.targetScreen, screenPropertiesData.deviceScreen);
        }

        #endregion

        #region Main Function

        public static void PlayTimeline(PlayableAsset timeline, Action onTimelineFinishCallback)
        {
            // Setup Timeline
            playableDirector.playableAsset = timeline;

            // Setup onTimelineFInishCallback
            UIPopupManager.onTimelineFinishCallback = onTimelineFinishCallback;

            // Play Timeline
            playableDirector.Play();
        }

        public static void OnTimelineFinishCallback()
        {
            onTimelineFinishCallback?.Invoke();
        }

        #endregion
    }
}