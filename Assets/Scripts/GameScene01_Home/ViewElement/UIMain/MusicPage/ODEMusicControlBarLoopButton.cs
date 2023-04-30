using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HomeScene.UIMain.MusicPage
{
    public class ODEMusicControlBarLoopButton : ClickableObjectBase
    {
        #region Declaration

        [Header("Selected")]
        [SerializeField] private GameObject selected;
        [SerializeField] private GameObject unselected;

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

        public void SetSelected(bool isSelected)
        {
            selected.SetActive(isSelected == true);
            unselected.SetActive(isSelected == false);
        }

        #endregion
    }
}