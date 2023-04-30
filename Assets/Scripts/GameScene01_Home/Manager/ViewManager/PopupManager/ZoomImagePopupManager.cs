using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using HomeScene.UIPopup;

namespace HomeScene
{
    public class ZoomImagePopupManager : MonoBehaviour
    {
        #region Declaration

        private UIPopup.ZoomImagePopup.ZoomImagePopup zoomImagePopup;

        [Header("Timeline")]
        [SerializeField] private PlayableAsset zoomImagePopupMoveInTimeline;
        [SerializeField] private PlayableAsset zoomImagePopupMoveOutTimeline;

        #endregion

        #region Init Stage

        public void InitManager()
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            zoomImagePopup = null;
        }

        #endregion

        #region Setup Stage

        public void SetupManager(UIPopup.ZoomImagePopup.ZoomImagePopup zoomImagePopup)
        {
            Debug.Log("--- " + this.GetType().Name + ": " + System.Reflection.MethodBase.GetCurrentMethod().Name + " ---");

            this.zoomImagePopup = zoomImagePopup;
        }

        #endregion

        #region Main Function

        /* ----- Init Element ----- */

        public void InitElements()
        {
            zoomImagePopup.oSECrossButton.InitElement();
            zoomImagePopup.oSELeftButton.InitElement();
            zoomImagePopup.oSERightButton.InitElement();
            zoomImagePopup.uDEZoomImage.InitElement();
    }

        /* ----- Setup Element ----- */

        public void SetupOSECrossButton(Action onPointerClickCallback)
        {
            zoomImagePopup.oSECrossButton.SetupElement(onPointerClickCallback);
        }

        public void SetupOSELeftButton(Action onPointerClickCallback)
        {
            zoomImagePopup.oSELeftButton.SetupElement(onPointerClickCallback);
        }

        public void SetupOSERightButton(Action onPointerClickCallback)
        {
            zoomImagePopup.oSERightButton.SetupElement(onPointerClickCallback);
        }

        public void SetupUDEZoomImage(Sprite sprite)
        {
            zoomImagePopup.uDEZoomImage.SetupElement(sprite);
        }

        public void UpdateImage(Sprite sprite)
        {
            zoomImagePopup.uDEZoomImage.UpdateImage(sprite);
        }

        /* ----- Timeline ----- */

        public void PlayZoomImagePopupMoveInTimeline(Action finishCallback)
        {
            UIPopupManager.PlayTimeline(zoomImagePopupMoveInTimeline, finishCallback);
        }

        public void PlayZoomImagePopupMoveOutTimeline(Action finishCallback)
        {
            UIPopupManager.PlayTimeline(zoomImagePopupMoveOutTimeline, finishCallback);
        }

        #endregion
    }
}