using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace HomeScene.UIMain.GalleryPage
{
    public class ODEScopeButtonListScopeButton : ClickableObjectBase
    {
        #region Declaration

        [Header("Selected")]
        [SerializeField]
        private GameObject selectedLine;

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
            selectedLine.SetActive(isSelected == true);
        }

        #endregion
    }
}