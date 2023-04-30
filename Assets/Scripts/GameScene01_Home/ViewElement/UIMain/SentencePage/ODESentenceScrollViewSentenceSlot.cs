using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace HomeScene.UIMain.SentencePage
{
    public class ODESentenceScrollViewSentenceSlot : ClickableObjectBase
    {
        #region Declaration

        [Header("Text")]
        [SerializeField] private TMP_Text contentSentenceText001;
        [SerializeField] private TMP_Text contentSpeakerText001;

        #endregion

        #region Init Stage

        public void InitElement()
        {
            // Init Text
            contentSentenceText001.text = "";
            contentSpeakerText001.text = "";

            // Init Action
            onPointerClickCallback = null;
        }

        #endregion

        #region Setup Stage

        public void SetupElement(TMP_FontAsset fontAsset, TextContentBase.SentencePage.UDESentenceScrollViewSentenceSlot textContent, Action onPointerClickCallback)
        {
            // Setup FontAsset
            contentSentenceText001.font = fontAsset;
            contentSpeakerText001.font = fontAsset;

            // Setup TextContent
            contentSentenceText001.text = textContent.contentSentenceText001;
            contentSpeakerText001.text = textContent.contentSpeakerText001;

            // Setup Action
            this.onPointerClickCallback = onPointerClickCallback;
        }

        #endregion

        #region Main Function

        // Comment: No Main Function

        #endregion
    }
}