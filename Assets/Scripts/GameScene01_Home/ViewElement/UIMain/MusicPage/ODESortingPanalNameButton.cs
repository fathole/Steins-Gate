using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HomeScene.UIMain.MusicPage
{
    public class ODESortingPanalNameButton : ClickableObjectBase
    {
        #region Declaration

        [Header("Selected")]
        [SerializeField]
        private GameObject selectedTick;

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
            // Init action
            this.onPointerClickCallback = onPointerClickCallback;
        }

        #endregion

        #region Main Function

        public void SetSelected(bool isSelected)
        {
            selectedTick.SetActive(isSelected == true);
        }

        #endregion
    }
}