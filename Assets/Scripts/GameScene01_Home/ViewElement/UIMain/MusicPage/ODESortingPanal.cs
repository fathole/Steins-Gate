using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace HomeScene.UIMain.MusicPage
{
    public class ODESortingPanal : ClickableObjectBase
    {
        #region Declaration

        [Header("Text")]
        [SerializeField] private TMP_Text panelContentNameButtonContentText001;
        [SerializeField] private TMP_Text panelContentLengthButtonContentText001;

        [Header("Child")]
        [SerializeField] private ODESortingPanalNameButton nameButton;
        [SerializeField] private ODESortingPanalLengthButton lengthButton;

        #endregion

        #region Init Stage

        public void InitElement()
        {
            // Init Child
            nameButton.InitElement();
            lengthButton.InitElement();

            // Init Action
            onPointerClickCallback = null;

            // Init Text
            panelContentNameButtonContentText001.text = "";
            panelContentLengthButtonContentText001.text = "";
        }

        #endregion

        #region Setup Stage

        public void SetupElement(TMP_FontAsset fontAsset, TextContentBase.MusicPage.ODESortingPanal textContent, MusicPageSortingOption musicPageSortingOption, Action onPointerClickCallback, Action onNameButtonPointerClickCallback, Action onLengthButtonPointerClickCallback)
        {
            // Setup Font Asset
            panelContentNameButtonContentText001.font = fontAsset;
            panelContentLengthButtonContentText001.font = fontAsset;

            // Setup Text Content
            panelContentNameButtonContentText001.text = textContent.panelContentNameButtonContentText001;
            panelContentLengthButtonContentText001.text = textContent.panelContentLengthButtonContentText001;

            // Setup Action
            this.onPointerClickCallback = onPointerClickCallback;

            // Setup Child
            nameButton.SetupElement(onNameButtonPointerClickCallback);
            lengthButton.SetupElement(onLengthButtonPointerClickCallback);
            SetSelected(musicPageSortingOption);
        }

        #endregion

        #region Main Function

        public void SetSelected(MusicPageSortingOption musicPageSortingOption )
        {
            nameButton.SetSelected(musicPageSortingOption == MusicPageSortingOption.Name);
            lengthButton.SetSelected(musicPageSortingOption == MusicPageSortingOption.Length);
        }

        #endregion
    }
}