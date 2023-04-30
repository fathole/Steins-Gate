using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HomeScene.UIMain.MusicPage
{
    public class ODEMusicControlBarProgressBar : ClickableObjectBase
    {
        #region Declaration

        [Header("Slider")]
        [SerializeField] private Slider progressBarSlider;        

        #endregion

        #region Init Stage

        public void InitElement()
        {
            // Init Action
            progressBarSlider.onValueChanged.RemoveAllListeners();
            onPointerDownCallback = null;
            onPointerUpCallback = null;

            progressBarSlider.interactable = false;
        }

        #endregion

        #region Setup Stage

        public void SetupElement(Action onProgressBarValueChangeCallback, Action onPointerDownCallback, Action onPointerUpCallback)
        {
            // Setup Action
            progressBarSlider.onValueChanged.AddListener(delegate { onProgressBarValueChangeCallback?.Invoke(); });
            this.onPointerDownCallback = onPointerDownCallback;
            this.onPointerUpCallback = onPointerUpCallback;
        }

        #endregion

        #region Main Function

        public void UpdateProgressBar(float clipLength, float currentTime)
        {
            if(progressBarSlider.interactable == false)
            {
                progressBarSlider.interactable = true;
            }

            progressBarSlider.maxValue = clipLength;
            progressBarSlider.value = currentTime;
        }

        public float GetProgressBarValue()
        {
            return progressBarSlider.value;
        }

        #endregion
    }
}