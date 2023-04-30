using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace HomeScene.UIMain.MusicPage
{
    public class ODESortingButton : ClickableObjectBase
    {
        #region Declaration

        [Header("Text")]
        [SerializeField] private TMP_Text contentText001;

        #endregion

        #region Init Stage

        public void InitElement()
        {
            // Init Text
            contentText001.text = "";

            // Init Action
            this.onPointerClickCallback = null;
        }

        #endregion

        #region Setup Stage

        public void SetupElement(TMP_FontAsset fontAsset, TextContentBase.MusicPage.ODESortingButton textContent, Action onPointerClickCallback)
        {
            // Setup Font Asset
            contentText001.font = fontAsset;

            // Setup Text Content
            contentText001.text = textContent.contentText001;

            // Setup Action
            this.onPointerClickCallback = onPointerClickCallback;
        }

        #endregion

        #region Main Function

        // Comment: No Main Function

        #endregion
    }
}