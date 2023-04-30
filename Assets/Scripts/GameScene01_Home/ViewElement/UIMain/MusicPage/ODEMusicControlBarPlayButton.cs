using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HomeScene.UIMain.MusicPage
{
    public class ODEMusicControlBarPlayButton : ClickableObjectBase
    {
        #region Declaration

        [Header("Selected")]
        [SerializeField] private GameObject playIcon;
        [SerializeField] private GameObject pauseIcon;

        #endregion

        #region Init Stage

        public void InitElement()
        {
            // Init action
            onPointerClickCallback = null;
        }

        #endregion

        #region Setup Stage

        public void SetupElement(Action onPointerClickCallback)
        {
            // Setup action
            this.onPointerClickCallback = onPointerClickCallback;
        }

        #endregion

        #region Main Function

        public void SetIcon(bool isPlaying)
        {
            playIcon.SetActive(isPlaying != true);
            pauseIcon.SetActive(isPlaying == true);
        }

        #endregion
    }
}