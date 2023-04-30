using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace HomeScene.UIMain.MusicPage
{
    public class ODEMusicScrollViewMusicSlot : ClickableObjectBase
    {
        #region Declaration

        [Header("Text")]
        [SerializeField] private TMP_Text contentMusicNameText001;
        [SerializeField] private TMP_Text contentMusicLengthText001;

        #endregion

        #region Init Stage

        public void InitElement()
        {
            // Init Text
            contentMusicNameText001.text = "";
            contentMusicLengthText001.text = "";

            // Init action
            onPointerClickCallback = null;
        }

        #endregion

        #region Setup Stage

        public void SetupElement(TMP_FontAsset fontAsset, TextContentBase.MusicPage.ODEMusicScrollViewMusicSlot textContent, string musicName, float clipLength, Action onPointerClickCallback)
        {
            // Setup Font Asset
            contentMusicNameText001.font = fontAsset;
            contentMusicLengthText001.font = fontAsset;                        

            // Update Text Content
            textContent.contentMusicNameText001 = textContent.contentMusicNameText001.Replace("{0}", musicName);
            textContent.contentMusicLengthText001 = textContent.contentMusicLengthText001.Replace("{0}", ((int)clipLength / 60).ToString("D2")).Replace("{1}", ((int)clipLength % 60).ToString("D2")) ;

            // Setup Text Content
            contentMusicNameText001.text = textContent.contentMusicNameText001;
            contentMusicLengthText001.text = textContent.contentMusicLengthText001;

            // Setup Action
            this.onPointerClickCallback = onPointerClickCallback;
        }

        #endregion

        #region Main Function

        // Comment: No Main Function

        #endregion
    }
}